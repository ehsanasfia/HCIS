namespace HCISStandAdmission.Dialogs
{
    partial class dlgDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDoctors));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.staffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colMedicalSystemCode = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMedicalSystemCode = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colSpecialityDegree = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colSpecialityDegree = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colPerson = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPerson = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colSpeciality = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colSpeciality = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colRoomNumber = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colRoomNumber = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMedicalSystemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSpecialityDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSpeciality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRoomNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(908, 523);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.staffBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(16, 16);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(876, 491);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // staffBindingSource
            // 
            this.staffBindingSource.DataSource = typeof(HCISStandAdmission.Data.Staff);
            // 
            // layoutView1
            // 
            this.layoutView1.CardHorzInterval = 13;
            this.layoutView1.CardMinSize = new System.Drawing.Size(146, 405);
            this.layoutView1.CardVertInterval = 0;
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colMedicalSystemCode,
            this.colSpecialityDegree,
            this.gridColumn1,
            this.colPerson,
            this.colSpeciality,
            this.colRoomNumber,
            this.gridColumn2});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.OptionsCustomization.AllowFilter = false;
            this.layoutView1.OptionsCustomization.AllowSort = false;
            this.layoutView1.OptionsCustomization.ShowGroupCardCaptions = false;
            this.layoutView1.OptionsCustomization.ShowGroupCardIndents = false;
            this.layoutView1.OptionsCustomization.ShowGroupCards = false;
            this.layoutView1.OptionsCustomization.ShowGroupFields = false;
            this.layoutView1.OptionsCustomization.ShowGroupHiddenItems = false;
            this.layoutView1.OptionsCustomization.ShowGroupLayout = false;
            this.layoutView1.OptionsCustomization.ShowGroupLayoutTreeView = false;
            this.layoutView1.OptionsCustomization.ShowGroupView = false;
            this.layoutView1.OptionsCustomization.ShowResetShrinkButtons = false;
            this.layoutView1.OptionsCustomization.ShowSaveLoadLayoutButtons = false;
            this.layoutView1.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            this.layoutView1.DoubleClick += new System.EventHandler(this.layoutView1_DoubleClick);
            // 
            // colMedicalSystemCode
            // 
            this.colMedicalSystemCode.Caption = "نظام پزشکی";
            this.colMedicalSystemCode.FieldName = "MedicalSystemCode";
            this.colMedicalSystemCode.LayoutViewField = this.layoutViewField_colMedicalSystemCode;
            this.colMedicalSystemCode.Name = "colMedicalSystemCode";
            this.colMedicalSystemCode.Width = 130;
            // 
            // layoutViewField_colMedicalSystemCode
            // 
            this.layoutViewField_colMedicalSystemCode.EditorPreferredWidth = 133;
            this.layoutViewField_colMedicalSystemCode.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colMedicalSystemCode.Name = "layoutViewField_colMedicalSystemCode";
            this.layoutViewField_colMedicalSystemCode.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_colMedicalSystemCode.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_colMedicalSystemCode.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_colMedicalSystemCode.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colMedicalSystemCode.TextSize = new System.Drawing.Size(80, 17);
            // 
            // colSpecialityDegree
            // 
            this.colSpecialityDegree.Caption = "درجه تخصص";
            this.colSpecialityDegree.FieldName = "SpecialityDegree";
            this.colSpecialityDegree.LayoutViewField = this.layoutViewField_colSpecialityDegree;
            this.colSpecialityDegree.Name = "colSpecialityDegree";
            // 
            // layoutViewField_colSpecialityDegree
            // 
            this.layoutViewField_colSpecialityDegree.EditorPreferredWidth = 133;
            this.layoutViewField_colSpecialityDegree.Location = new System.Drawing.Point(0, 50);
            this.layoutViewField_colSpecialityDegree.Name = "layoutViewField_colSpecialityDegree";
            this.layoutViewField_colSpecialityDegree.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_colSpecialityDegree.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_colSpecialityDegree.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_colSpecialityDegree.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colSpecialityDegree.TextSize = new System.Drawing.Size(80, 17);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "نام";
            this.gridColumn1.FieldName = "Person.FirstName";
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 126;
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 133;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 100);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_gridColumn1.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_gridColumn1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(80, 17);
            // 
            // colPerson
            // 
            this.colPerson.Caption = "نام خانوادگی";
            this.colPerson.FieldName = "Person.LastName";
            this.colPerson.LayoutViewField = this.layoutViewField_colPerson;
            this.colPerson.Name = "colPerson";
            this.colPerson.Width = 212;
            // 
            // layoutViewField_colPerson
            // 
            this.layoutViewField_colPerson.EditorPreferredWidth = 133;
            this.layoutViewField_colPerson.Location = new System.Drawing.Point(0, 150);
            this.layoutViewField_colPerson.Name = "layoutViewField_colPerson";
            this.layoutViewField_colPerson.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_colPerson.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_colPerson.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_colPerson.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colPerson.TextSize = new System.Drawing.Size(80, 17);
            // 
            // colSpeciality
            // 
            this.colSpeciality.Caption = "تخصص";
            this.colSpeciality.FieldName = "Speciality.Speciality1";
            this.colSpeciality.LayoutViewField = this.layoutViewField_colSpeciality;
            this.colSpeciality.Name = "colSpeciality";
            // 
            // layoutViewField_colSpeciality
            // 
            this.layoutViewField_colSpeciality.EditorPreferredWidth = 133;
            this.layoutViewField_colSpeciality.Location = new System.Drawing.Point(0, 200);
            this.layoutViewField_colSpeciality.Name = "layoutViewField_colSpeciality";
            this.layoutViewField_colSpeciality.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_colSpeciality.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_colSpeciality.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_colSpeciality.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colSpeciality.TextSize = new System.Drawing.Size(80, 17);
            // 
            // colRoomNumber
            // 
            this.colRoomNumber.Caption = "شماره اتاق";
            this.colRoomNumber.FieldName = "RoomNumber";
            this.colRoomNumber.LayoutViewField = this.layoutViewField_colRoomNumber;
            this.colRoomNumber.Name = "colRoomNumber";
            this.colRoomNumber.Width = 188;
            // 
            // layoutViewField_colRoomNumber
            // 
            this.layoutViewField_colRoomNumber.EditorPreferredWidth = 133;
            this.layoutViewField_colRoomNumber.Location = new System.Drawing.Point(0, 250);
            this.layoutViewField_colRoomNumber.Name = "layoutViewField_colRoomNumber";
            this.layoutViewField_colRoomNumber.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_colRoomNumber.Size = new System.Drawing.Size(241, 50);
            this.layoutViewField_colRoomNumber.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_colRoomNumber.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_colRoomNumber.TextSize = new System.Drawing.Size(80, 17);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "انتخاب";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 200;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Appearance.Image")));
            this.repositoryItemButtonEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.ContextImage = ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.ContextImage")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 133;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(0, 300);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(241, 64);
            this.layoutViewField_gridColumn2.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutViewField_gridColumn2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(80, 17);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colMedicalSystemCode,
            this.layoutViewField_colSpecialityDegree,
            this.layoutViewField_gridColumn1,
            this.layoutViewField_colPerson,
            this.layoutViewField_colSpeciality,
            this.layoutViewField_colRoomNumber,
            this.layoutViewField_gridColumn2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutViewCard1.Text = "TemplateCard";
            this.layoutViewCard1.TextLocation = DevExpress.Utils.Locations.Default;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(908, 523);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(882, 497);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dlgDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 523);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDoctors";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب پزشک";
            this.Load += new System.EventHandler(this.dlgDoctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMedicalSystemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSpecialityDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colSpeciality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colRoomNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource staffBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colMedicalSystemCode;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colSpecialityDegree;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPerson;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colSpeciality;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colRoomNumber;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMedicalSystemCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colSpecialityDegree;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPerson;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colSpeciality;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colRoomNumber;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}