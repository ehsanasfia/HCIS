namespace HCISAngio.Dialogs
{
    partial class dlgAngioHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAngioHistory));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.angioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colETT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChestPain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEcho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTalium = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTMC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHLP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCABG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMFU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.gridControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(691, 352, 312, 437);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(932, 453);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(932, 453);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.angioBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(16, 16);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(900, 375);
            this.gridControl2.TabIndex = 5;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colETT,
            this.colChestPain,
            this.colDOE,
            this.colEcho,
            this.colTalium,
            this.colCS,
            this.colFH,
            this.colDM,
            this.colPTMC,
            this.colHTN,
            this.colHLP,
            this.colResult,
            this.colCABG,
            this.colPCI,
            this.colMFU});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupPanelText = "برای گروه بندی بر اساس ستون، سرستون را به اینجا بکشید.";
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(906, 381);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(16, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 40);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "بستن";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 381);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(120, 46);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(120, 381);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(786, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // angioBindingSource
            // 
            this.angioBindingSource.DataSource = typeof(HCISAngio.Data.Angio);
            // 
            // colETT
            // 
            this.colETT.Caption = "ETT";
            this.colETT.FieldName = "ETT";
            this.colETT.Name = "colETT";
            this.colETT.Visible = true;
            this.colETT.VisibleIndex = 0;
            // 
            // colChestPain
            // 
            this.colChestPain.Caption = "ChestPain";
            this.colChestPain.FieldName = "ChestPain";
            this.colChestPain.Name = "colChestPain";
            this.colChestPain.Visible = true;
            this.colChestPain.VisibleIndex = 1;
            this.colChestPain.Width = 81;
            // 
            // colDOE
            // 
            this.colDOE.Caption = "DOE";
            this.colDOE.FieldName = "DOE";
            this.colDOE.Name = "colDOE";
            this.colDOE.Visible = true;
            this.colDOE.VisibleIndex = 2;
            // 
            // colEcho
            // 
            this.colEcho.Caption = "Echo";
            this.colEcho.FieldName = "Echo";
            this.colEcho.Name = "colEcho";
            this.colEcho.Visible = true;
            this.colEcho.VisibleIndex = 3;
            // 
            // colTalium
            // 
            this.colTalium.Caption = "Talium";
            this.colTalium.FieldName = "Talium";
            this.colTalium.Name = "colTalium";
            this.colTalium.Visible = true;
            this.colTalium.VisibleIndex = 4;
            // 
            // colCS
            // 
            this.colCS.Caption = "CS";
            this.colCS.FieldName = "CS";
            this.colCS.Name = "colCS";
            this.colCS.Visible = true;
            this.colCS.VisibleIndex = 5;
            // 
            // colFH
            // 
            this.colFH.Caption = "FH";
            this.colFH.FieldName = "FH";
            this.colFH.Name = "colFH";
            this.colFH.Visible = true;
            this.colFH.VisibleIndex = 6;
            // 
            // colDM
            // 
            this.colDM.Caption = "DM";
            this.colDM.FieldName = "DM";
            this.colDM.Name = "colDM";
            this.colDM.Visible = true;
            this.colDM.VisibleIndex = 7;
            // 
            // colPTMC
            // 
            this.colPTMC.Caption = "PTMC";
            this.colPTMC.FieldName = "PTMC";
            this.colPTMC.Name = "colPTMC";
            this.colPTMC.Visible = true;
            this.colPTMC.VisibleIndex = 8;
            // 
            // colHTN
            // 
            this.colHTN.Caption = "HTN";
            this.colHTN.FieldName = "HTN";
            this.colHTN.Name = "colHTN";
            this.colHTN.Visible = true;
            this.colHTN.VisibleIndex = 9;
            // 
            // colHLP
            // 
            this.colHLP.Caption = "HLP";
            this.colHLP.FieldName = "HLP";
            this.colHLP.Name = "colHLP";
            this.colHLP.Visible = true;
            this.colHLP.VisibleIndex = 10;
            // 
            // colResult
            // 
            this.colResult.Caption = "Result";
            this.colResult.FieldName = "Result";
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 11;
            // 
            // colCABG
            // 
            this.colCABG.Caption = "CABG";
            this.colCABG.FieldName = "CABG";
            this.colCABG.Name = "colCABG";
            this.colCABG.Visible = true;
            this.colCABG.VisibleIndex = 12;
            // 
            // colPCI
            // 
            this.colPCI.Caption = "PCI";
            this.colPCI.FieldName = "PCI";
            this.colPCI.Name = "colPCI";
            this.colPCI.Visible = true;
            this.colPCI.VisibleIndex = 13;
            // 
            // colMFU
            // 
            this.colMFU.Caption = "MFU";
            this.colMFU.FieldName = "MFU";
            this.colMFU.Name = "colMFU";
            this.colMFU.Visible = true;
            this.colMFU.VisibleIndex = 14;
            // 
            // dlgAngioHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(932, 453);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAngioHistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سوابق";
            this.Load += new System.EventHandler(this.dlgAngioHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource angioBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colETT;
        private DevExpress.XtraGrid.Columns.GridColumn colChestPain;
        private DevExpress.XtraGrid.Columns.GridColumn colDOE;
        private DevExpress.XtraGrid.Columns.GridColumn colEcho;
        private DevExpress.XtraGrid.Columns.GridColumn colTalium;
        private DevExpress.XtraGrid.Columns.GridColumn colCS;
        private DevExpress.XtraGrid.Columns.GridColumn colFH;
        private DevExpress.XtraGrid.Columns.GridColumn colDM;
        private DevExpress.XtraGrid.Columns.GridColumn colPTMC;
        private DevExpress.XtraGrid.Columns.GridColumn colHTN;
        private DevExpress.XtraGrid.Columns.GridColumn colHLP;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colCABG;
        private DevExpress.XtraGrid.Columns.GridColumn colPCI;
        private DevExpress.XtraGrid.Columns.GridColumn colMFU;
    }
}