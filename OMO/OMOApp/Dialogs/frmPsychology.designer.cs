namespace OMOApp.Dialogs
{
    partial class frmPsychology
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.DASS42DateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.psychologyTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DASS42TimeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StressScoreSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.StressResultComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.AnxietyScoreSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.AnxietyResultComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DepressionScoreSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.DepressionResultComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDASS42Date = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDepressionResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDepressionScore = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAnxietyResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAnxietyScore = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStressResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStressScore = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDASS42Time = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DASS42DateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psychologyTestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DASS42TimeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressScoreSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressResultComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnxietyScoreSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnxietyResultComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepressionScoreSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepressionResultComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDASS42Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepressionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepressionScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnxietyResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnxietyScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStressResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStressScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDASS42Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.DASS42DateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DASS42TimeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StressScoreSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.StressResultComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.AnxietyScoreSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.AnxietyResultComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.DepressionScoreSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.DepressionResultComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.psychologyTestBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.dataLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AutoSize;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(618, 525);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // DASS42DateTextEdit
            // 
            this.DASS42DateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.psychologyTestBindingSource, "DASS42Date", true));
            this.DASS42DateTextEdit.EnterMoveNextControl = true;
            this.DASS42DateTextEdit.Location = new System.Drawing.Point(413, 43);
            this.DASS42DateTextEdit.Name = "DASS42DateTextEdit";
            this.DASS42DateTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DASS42DateTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.DASS42DateTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DASS42DateTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.DASS42DateTextEdit.Properties.Mask.EditMask = "([12][0-9])[0-9][0-9]/(0[1-9]|1[012])/([012][0-9]|30|31)";
            this.DASS42DateTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.DASS42DateTextEdit.Size = new System.Drawing.Size(131, 20);
            this.DASS42DateTextEdit.StyleController = this.dataLayoutControl1;
            this.DASS42DateTextEdit.TabIndex = 4;
            // 
            // psychologyTestBindingSource
            // 
            this.psychologyTestBindingSource.DataSource = typeof(OMOApp.Data.IMData.PsychologyTest);
            // 
            // DASS42TimeTextEdit
            // 
            this.DASS42TimeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.psychologyTestBindingSource, "DASS42Time", true));
            this.DASS42TimeTextEdit.EnterMoveNextControl = true;
            this.DASS42TimeTextEdit.Location = new System.Drawing.Point(310, 43);
            this.DASS42TimeTextEdit.Name = "DASS42TimeTextEdit";
            this.DASS42TimeTextEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DASS42TimeTextEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.DASS42TimeTextEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DASS42TimeTextEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.DASS42TimeTextEdit.Properties.Mask.EditMask = "90:00";
            this.DASS42TimeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.DASS42TimeTextEdit.Size = new System.Drawing.Size(65, 20);
            this.DASS42TimeTextEdit.StyleController = this.dataLayoutControl1;
            this.DASS42TimeTextEdit.TabIndex = 5;
            // 
            // StressScoreSpinEdit
            // 
            this.StressScoreSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.psychologyTestBindingSource, "StressScore", true));
            this.StressScoreSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.StressScoreSpinEdit.EnterMoveNextControl = true;
            this.StressScoreSpinEdit.Location = new System.Drawing.Point(310, 67);
            this.StressScoreSpinEdit.Name = "StressScoreSpinEdit";
            this.StressScoreSpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StressScoreSpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.StressScoreSpinEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.StressScoreSpinEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.StressScoreSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.StressScoreSpinEdit.Properties.Mask.EditMask = "d";
            this.StressScoreSpinEdit.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.StressScoreSpinEdit.Size = new System.Drawing.Size(224, 20);
            this.StressScoreSpinEdit.StyleController = this.dataLayoutControl1;
            this.StressScoreSpinEdit.TabIndex = 6;
            this.StressScoreSpinEdit.EditValueChanged += new System.EventHandler(this.StressScoreSpinEdit_EditValueChanged);
            // 
            // StressResultComboBoxEdit
            // 
            this.StressResultComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.psychologyTestBindingSource, "StressResult", true));
            this.StressResultComboBoxEdit.EnterMoveNextControl = true;
            this.StressResultComboBoxEdit.Location = new System.Drawing.Point(310, 91);
            this.StressResultComboBoxEdit.Name = "StressResultComboBoxEdit";
            this.StressResultComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StressResultComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.StressResultComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.StressResultComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.StressResultComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StressResultComboBoxEdit.Properties.Items.AddRange(new object[] {
            "طبیعی",
            "خفیف",
            "متوسط",
            "شدید",
            "خیلی شدید"});
            this.StressResultComboBoxEdit.Properties.ReadOnly = true;
            this.StressResultComboBoxEdit.Size = new System.Drawing.Size(224, 20);
            this.StressResultComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.StressResultComboBoxEdit.TabIndex = 7;
            // 
            // AnxietyScoreSpinEdit
            // 
            this.AnxietyScoreSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.psychologyTestBindingSource, "AnxietyScore", true));
            this.AnxietyScoreSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.AnxietyScoreSpinEdit.EnterMoveNextControl = true;
            this.AnxietyScoreSpinEdit.Location = new System.Drawing.Point(310, 115);
            this.AnxietyScoreSpinEdit.Name = "AnxietyScoreSpinEdit";
            this.AnxietyScoreSpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AnxietyScoreSpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.AnxietyScoreSpinEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.AnxietyScoreSpinEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.AnxietyScoreSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.AnxietyScoreSpinEdit.Properties.Mask.EditMask = "d";
            this.AnxietyScoreSpinEdit.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AnxietyScoreSpinEdit.Size = new System.Drawing.Size(217, 20);
            this.AnxietyScoreSpinEdit.StyleController = this.dataLayoutControl1;
            this.AnxietyScoreSpinEdit.TabIndex = 8;
            this.AnxietyScoreSpinEdit.EditValueChanged += new System.EventHandler(this.AnxietyScoreSpinEdit_EditValueChanged);
            // 
            // AnxietyResultComboBoxEdit
            // 
            this.AnxietyResultComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.psychologyTestBindingSource, "AnxietyResult", true));
            this.AnxietyResultComboBoxEdit.EnterMoveNextControl = true;
            this.AnxietyResultComboBoxEdit.Location = new System.Drawing.Point(310, 139);
            this.AnxietyResultComboBoxEdit.Name = "AnxietyResultComboBoxEdit";
            this.AnxietyResultComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AnxietyResultComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.AnxietyResultComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.AnxietyResultComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.AnxietyResultComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AnxietyResultComboBoxEdit.Properties.Items.AddRange(new object[] {
            "طبیعی",
            "خفیف",
            "متوسط",
            "شدید",
            "خیلی شدید"});
            this.AnxietyResultComboBoxEdit.Properties.ReadOnly = true;
            this.AnxietyResultComboBoxEdit.Size = new System.Drawing.Size(217, 20);
            this.AnxietyResultComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.AnxietyResultComboBoxEdit.TabIndex = 9;
            // 
            // DepressionScoreSpinEdit
            // 
            this.DepressionScoreSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.psychologyTestBindingSource, "DepressionScore", true));
            this.DepressionScoreSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DepressionScoreSpinEdit.EnterMoveNextControl = true;
            this.DepressionScoreSpinEdit.Location = new System.Drawing.Point(310, 163);
            this.DepressionScoreSpinEdit.Name = "DepressionScoreSpinEdit";
            this.DepressionScoreSpinEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DepressionScoreSpinEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.DepressionScoreSpinEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DepressionScoreSpinEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.DepressionScoreSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DepressionScoreSpinEdit.Properties.Mask.EditMask = "d";
            this.DepressionScoreSpinEdit.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DepressionScoreSpinEdit.Size = new System.Drawing.Size(201, 20);
            this.DepressionScoreSpinEdit.StyleController = this.dataLayoutControl1;
            this.DepressionScoreSpinEdit.TabIndex = 10;
            this.DepressionScoreSpinEdit.EditValueChanged += new System.EventHandler(this.DepressionScoreSpinEdit_EditValueChanged);
            // 
            // DepressionResultComboBoxEdit
            // 
            this.DepressionResultComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.psychologyTestBindingSource, "DepressionResult", true));
            this.DepressionResultComboBoxEdit.EnterMoveNextControl = true;
            this.DepressionResultComboBoxEdit.Location = new System.Drawing.Point(310, 187);
            this.DepressionResultComboBoxEdit.Name = "DepressionResultComboBoxEdit";
            this.DepressionResultComboBoxEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DepressionResultComboBoxEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.DepressionResultComboBoxEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DepressionResultComboBoxEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.DepressionResultComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DepressionResultComboBoxEdit.Properties.Items.AddRange(new object[] {
            "طبیعی",
            "خفیف",
            "متوسط",
            "شدید",
            "خیلی شدید"});
            this.DepressionResultComboBoxEdit.Properties.ReadOnly = true;
            this.DepressionResultComboBoxEdit.Size = new System.Drawing.Size(201, 20);
            this.DepressionResultComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.DepressionResultComboBoxEdit.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(618, 525);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(598, 505);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(286, 505);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "تست DASS 42";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDASS42Date,
            this.ItemForDepressionResult,
            this.ItemForDepressionScore,
            this.ItemForAnxietyResult,
            this.ItemForAnxietyScore,
            this.ItemForStressResult,
            this.ItemForStressScore,
            this.ItemForDASS42Time,
            this.emptySpaceItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(286, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(312, 505);
            this.layoutControlGroup3.Text = "تست DASS 42";
            // 
            // ItemForDASS42Date
            // 
            this.ItemForDASS42Date.Control = this.DASS42DateTextEdit;
            this.ItemForDASS42Date.CustomizationFormText = "تاریخ انجام";
            this.ItemForDASS42Date.Location = new System.Drawing.Point(103, 0);
            this.ItemForDASS42Date.Name = "ItemForDASS42Date";
            this.ItemForDASS42Date.Size = new System.Drawing.Size(185, 24);
            this.ItemForDASS42Date.Text = "تاریخ انجام";
            this.ItemForDASS42Date.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForDASS42Date.TextSize = new System.Drawing.Size(47, 13);
            // 
            // ItemForDepressionResult
            // 
            this.ItemForDepressionResult.Control = this.DepressionResultComboBoxEdit;
            this.ItemForDepressionResult.CustomizationFormText = "Depression نتیجه";
            this.ItemForDepressionResult.Location = new System.Drawing.Point(0, 144);
            this.ItemForDepressionResult.Name = "ItemForDepressionResult";
            this.ItemForDepressionResult.Size = new System.Drawing.Size(288, 24);
            this.ItemForDepressionResult.Text = "Depression نتیجه";
            this.ItemForDepressionResult.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForDepressionResult.TextSize = new System.Drawing.Size(80, 13);
            // 
            // ItemForDepressionScore
            // 
            this.ItemForDepressionScore.Control = this.DepressionScoreSpinEdit;
            this.ItemForDepressionScore.CustomizationFormText = "Depression امتیاز";
            this.ItemForDepressionScore.Location = new System.Drawing.Point(0, 120);
            this.ItemForDepressionScore.Name = "ItemForDepressionScore";
            this.ItemForDepressionScore.Size = new System.Drawing.Size(288, 24);
            this.ItemForDepressionScore.Text = "Depression امتیاز";
            this.ItemForDepressionScore.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForDepressionScore.TextSize = new System.Drawing.Size(80, 13);
            // 
            // ItemForAnxietyResult
            // 
            this.ItemForAnxietyResult.Control = this.AnxietyResultComboBoxEdit;
            this.ItemForAnxietyResult.CustomizationFormText = "Anxiety نتیجه";
            this.ItemForAnxietyResult.Location = new System.Drawing.Point(0, 96);
            this.ItemForAnxietyResult.Name = "ItemForAnxietyResult";
            this.ItemForAnxietyResult.Size = new System.Drawing.Size(288, 24);
            this.ItemForAnxietyResult.Text = "Anxiety نتیجه";
            this.ItemForAnxietyResult.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForAnxietyResult.TextSize = new System.Drawing.Size(64, 13);
            // 
            // ItemForAnxietyScore
            // 
            this.ItemForAnxietyScore.Control = this.AnxietyScoreSpinEdit;
            this.ItemForAnxietyScore.CustomizationFormText = "Anxiety امتیاز";
            this.ItemForAnxietyScore.Location = new System.Drawing.Point(0, 72);
            this.ItemForAnxietyScore.Name = "ItemForAnxietyScore";
            this.ItemForAnxietyScore.Size = new System.Drawing.Size(288, 24);
            this.ItemForAnxietyScore.Text = "Anxiety امتیاز";
            this.ItemForAnxietyScore.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForAnxietyScore.TextSize = new System.Drawing.Size(64, 13);
            // 
            // ItemForStressResult
            // 
            this.ItemForStressResult.Control = this.StressResultComboBoxEdit;
            this.ItemForStressResult.CustomizationFormText = "Stress نتیجه";
            this.ItemForStressResult.Location = new System.Drawing.Point(0, 48);
            this.ItemForStressResult.Name = "ItemForStressResult";
            this.ItemForStressResult.Size = new System.Drawing.Size(288, 24);
            this.ItemForStressResult.Text = "Stress نتیجه";
            this.ItemForStressResult.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForStressResult.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForStressScore
            // 
            this.ItemForStressScore.Control = this.StressScoreSpinEdit;
            this.ItemForStressScore.CustomizationFormText = "Stress امتیاز";
            this.ItemForStressScore.Location = new System.Drawing.Point(0, 24);
            this.ItemForStressScore.Name = "ItemForStressScore";
            this.ItemForStressScore.Size = new System.Drawing.Size(288, 24);
            this.ItemForStressScore.Text = "Stress امتیاز";
            this.ItemForStressScore.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForStressScore.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ItemForDASS42Time
            // 
            this.ItemForDASS42Time.Control = this.DASS42TimeTextEdit;
            this.ItemForDASS42Time.CustomizationFormText = "ساعت";
            this.ItemForDASS42Time.Location = new System.Drawing.Point(0, 0);
            this.ItemForDASS42Time.Name = "ItemForDASS42Time";
            this.ItemForDASS42Time.Size = new System.Drawing.Size(103, 24);
            this.ItemForDASS42Time.Text = "ساعت";
            this.ItemForDASS42Time.TextLocation = DevExpress.Utils.Locations.Right;
            this.ItemForDASS42Time.TextSize = new System.Drawing.Size(31, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 168);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(288, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(288, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(288, 294);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPsychology
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 525);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "frmPsychology";
            this.Text = "روانشناسی صنعتی";
            this.Load += new System.EventHandler(this.frmPsychology_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DASS42DateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psychologyTestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DASS42TimeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressScoreSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressResultComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnxietyScoreSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnxietyResultComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepressionScoreSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepressionResultComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDASS42Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepressionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepressionScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnxietyResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAnxietyScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStressResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStressScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDASS42Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit DASS42DateTextEdit;
        private System.Windows.Forms.BindingSource psychologyTestBindingSource;
        private DevExpress.XtraEditors.TextEdit DASS42TimeTextEdit;
        private DevExpress.XtraEditors.SpinEdit StressScoreSpinEdit;
        private DevExpress.XtraEditors.ComboBoxEdit StressResultComboBoxEdit;
        private DevExpress.XtraEditors.SpinEdit AnxietyScoreSpinEdit;
        private DevExpress.XtraEditors.ComboBoxEdit AnxietyResultComboBoxEdit;
        private DevExpress.XtraEditors.SpinEdit DepressionScoreSpinEdit;
        private DevExpress.XtraEditors.ComboBoxEdit DepressionResultComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDASS42Date;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepressionResult;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepressionScore;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAnxietyResult;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAnxietyScore;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStressResult;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStressScore;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDASS42Time;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;

    }
}