namespace HCISDefinitions.Dialogs
{
    partial class dlgPeriodicCalender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPeriodicCalender));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.txtFromDate = new DevExpress.XtraEditors.TextEdit();
            this.rbtnShift = new DevExpress.XtraEditors.RadioGroup();
            this.chkDays = new System.Windows.Forms.CheckedListBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.spnCapecity = new DevExpress.XtraEditors.SpinEdit();
            this.txtFromClock = new DevExpress.XtraEditors.TextEdit();
            this.txtToclock = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCapecity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromClock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToclock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.spinEdit1);
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Controls.Add(this.txtFromDate);
            this.layoutControl1.Controls.Add(this.rbtnShift);
            this.layoutControl1.Controls.Add(this.chkDays);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.spnCapecity);
            this.layoutControl1.Controls.Add(this.txtFromClock);
            this.layoutControl1.Controls.Add(this.txtToclock);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(541, 334);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtToDate
            // 
            this.txtToDate.EnterMoveNextControl = true;
            this.txtToDate.Location = new System.Drawing.Point(21, 21);
            this.txtToDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtToDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtToDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtToDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtToDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtToDate.Size = new System.Drawing.Size(123, 22);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 16;
            // 
            // txtFromDate
            // 
            this.txtFromDate.EnterMoveNextControl = true;
            this.txtFromDate.Location = new System.Drawing.Point(277, 21);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFromDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFromDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFromDate.Properties.Mask.EditMask = "(1[34])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.txtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFromDate.Size = new System.Drawing.Size(126, 22);
            this.txtFromDate.StyleController = this.layoutControl1;
            this.txtFromDate.TabIndex = 15;
            // 
            // rbtnShift
            // 
            this.rbtnShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnShift.EnterMoveNextControl = true;
            this.rbtnShift.Location = new System.Drawing.Point(21, 79);
            this.rbtnShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnShift.Name = "rbtnShift";
            this.rbtnShift.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "صبح"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "ظهر"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "شب")});
            this.rbtnShift.Size = new System.Drawing.Size(240, 112);
            this.rbtnShift.StyleController = this.layoutControl1;
            this.rbtnShift.TabIndex = 14;
            // 
            // chkDays
            // 
            this.chkDays.CheckOnClick = true;
            this.chkDays.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDays.FormattingEnabled = true;
            this.chkDays.IntegralHeight = false;
            this.chkDays.Items.AddRange(new object[] {
            "شنبه",
            "یکشنبه",
            "دوشنبه",
            "سه شنبه",
            "چهارشنبه",
            "پنج شنبه",
            "جمعه"});
            this.chkDays.Location = new System.Drawing.Point(274, 76);
            this.chkDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDays.Name = "chkDays";
            this.chkDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDays.Size = new System.Drawing.Size(249, 118);
            this.chkDays.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(142, 278);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 40);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(16, 278);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spnCapecity
            // 
            this.spnCapecity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnCapecity.EnterMoveNextControl = true;
            this.spnCapecity.Location = new System.Drawing.Point(277, 207);
            this.spnCapecity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spnCapecity.Name = "spnCapecity";
            this.spnCapecity.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spnCapecity.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.spnCapecity.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.spnCapecity.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.spnCapecity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnCapecity.Properties.Mask.EditMask = "d0";
            this.spnCapecity.Size = new System.Drawing.Size(126, 22);
            this.spnCapecity.StyleController = this.layoutControl1;
            this.spnCapecity.TabIndex = 10;
            this.spnCapecity.EditValueChanged += new System.EventHandler(this.spnCapecity_EditValueChanged);
            // 
            // txtFromClock
            // 
            this.txtFromClock.EnterMoveNextControl = true;
            this.txtFromClock.Location = new System.Drawing.Point(277, 245);
            this.txtFromClock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFromClock.Name = "txtFromClock";
            this.txtFromClock.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFromClock.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFromClock.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFromClock.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFromClock.Properties.Mask.EditMask = "[0-9][0-9]:[0-9][0-9]";
            this.txtFromClock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFromClock.Size = new System.Drawing.Size(126, 22);
            this.txtFromClock.StyleController = this.layoutControl1;
            this.txtFromClock.TabIndex = 9;
            // 
            // txtToclock
            // 
            this.txtToclock.EnterMoveNextControl = true;
            this.txtToclock.Location = new System.Drawing.Point(21, 245);
            this.txtToclock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtToclock.Name = "txtToclock";
            this.txtToclock.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtToclock.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtToclock.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtToclock.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtToclock.Properties.Mask.EditMask = "[0-9][0-9]:[0-9][0-9]";
            this.txtToclock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtToclock.Size = new System.Drawing.Size(123, 22);
            this.txtToclock.StyleController = this.layoutControl1;
            this.txtToclock.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem10});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(541, 334);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.Control = this.txtFromClock;
            this.layoutControlItem6.Location = new System.Drawing.Point(256, 224);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(259, 38);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Text = "از ساعت:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem5.Control = this.txtToclock;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 224);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(256, 38);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Text = "تا ساعت:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnCancel;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 262);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(126, 46);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnOk;
            this.layoutControlItem9.Location = new System.Drawing.Point(126, 262);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(130, 46);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(256, 262);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(259, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem3.Control = this.txtFromDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(259, 38);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Text = "از تاریخ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem4.Control = this.txtToDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(256, 38);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Text = "تا تاریخ:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem7.Control = this.spnCapecity;
            this.layoutControlItem7.Location = new System.Drawing.Point(256, 186);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(259, 38);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem7.Text = "ظرفیت:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem1.Control = this.chkDays;
            this.layoutControlItem1.Location = new System.Drawing.Point(256, 38);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(259, 148);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "روز:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(114, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rbtnShift;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(256, 148);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "شیفت:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 17);
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(21, 207);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.Mask.EditMask = "d";
            this.spinEdit1.Size = new System.Drawing.Size(123, 22);
            this.spinEdit1.StyleController = this.layoutControl1;
            this.spinEdit1.TabIndex = 17;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.spinEdit1;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 186);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(256, 38);
            this.layoutControlItem10.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem10.Text = "ظرفیت غیر حضوری:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(114, 17);
            // 
            // dlgPeriodicCalender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(541, 334);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPeriodicCalender";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "برنامه دوره ای";
            this.Load += new System.EventHandler(this.dlgPeriodicCalender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCapecity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromClock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToclock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SpinEdit spnCapecity;
        private DevExpress.XtraEditors.TextEdit txtFromClock;
        private DevExpress.XtraEditors.TextEdit txtToclock;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.CheckedListBox chkDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.RadioGroup rbtnShift;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraEditors.TextEdit txtFromDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}