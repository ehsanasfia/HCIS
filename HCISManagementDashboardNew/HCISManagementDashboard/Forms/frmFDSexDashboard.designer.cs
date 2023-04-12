namespace HCISManagementDashboard.Forms
{
    partial class frmFDSexDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFDSexDashboard));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dtpTo = new PersianDate.DatePicker();
            this.dtpFrom = new PersianDate.DatePicker();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.dashboardViewer1 = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dashboardBackstageViewControl1 = new DevExpress.DashboardWin.Bars.DashboardBackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.recentDashboardsControl1 = new DevExpress.DashboardWin.Bars.RecentDashboardsControl();
            this.dashboardBackstageRecentTab1 = new DevExpress.DashboardWin.Bars.DashboardBackstageRecentTab();
            this.dashboardBackstageNewButton1 = new DevExpress.DashboardWin.Bars.DashboardBackstageNewButton();
            this.dashboardBackstageOpenButton1 = new DevExpress.DashboardWin.Bars.DashboardBackstageOpenButton();
            this.dashboardBackstageSaveButton1 = new DevExpress.DashboardWin.Bars.DashboardBackstageSaveButton();
            this.dashboardBackstageSaveAsButton1 = new DevExpress.DashboardWin.Bars.DashboardBackstageSaveAsButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBackstageViewControl1)).BeginInit();
            this.dashboardBackstageViewControl1.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.dtpTo);
            this.layoutControl1.Controls.Add(this.dtpFrom);
            this.layoutControl1.Controls.Add(this.btnShow);
            this.layoutControl1.Controls.Add(this.dashboardViewer1);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(339, 340, 250, 350);
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1198, 662);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(19, 19);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(141, 20);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "چاپ همه";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Date = "1397/05/30";
            this.dtpTo.EnterMoveNext = false;
            this.dtpTo.FocusColor = System.Drawing.Color.Yellow;
            this.dtpTo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpTo.Location = new System.Drawing.Point(831, 19);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTo.Size = new System.Drawing.Size(120, 24);
            this.dtpTo.TabIndex = 7;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Date = "1397/05/30";
            this.dtpFrom.EnterMoveNext = false;
            this.dtpFrom.FocusColor = System.Drawing.Color.Yellow;
            this.dtpFrom.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dtpFrom.Location = new System.Drawing.Point(1004, 19);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFrom.Size = new System.Drawing.Size(120, 24);
            this.dtpFrom.TabIndex = 6;
            // 
            // btnShow
            // 
            this.btnShow.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnShow.Appearance.Options.UseFont = true;
            this.btnShow.Image = ((System.Drawing.Image)(resources.GetObject("btnShow.Image")));
            this.btnShow.Location = new System.Drawing.Point(703, 19);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(116, 20);
            this.btnShow.StyleController = this.layoutControl1;
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "نمایش";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dashboardViewer1
            // 
            this.dashboardViewer1.AllowPrintDashboardItems = true;
            this.dashboardViewer1.Location = new System.Drawing.Point(16, 48);
            this.dashboardViewer1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dashboardViewer1.Name = "dashboardViewer1";
            this.dashboardViewer1.Size = new System.Drawing.Size(1166, 598);
            this.dashboardViewer1.TabIndex = 4;
            this.dashboardViewer1.DashboardLoaded += new DevExpress.DashboardWin.DashboardLoadedEventHandler(this.dashboardViewer1_DashboardLoaded);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(172, 19);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 20);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "به روز رسانی";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1198, 662);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dashboardViewer1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1172, 604);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnShow;
            this.layoutControlItem2.Location = new System.Drawing.Point(684, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(128, 32);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(128, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(128, 32);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.dtpFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(985, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(187, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(187, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(187, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "تاریخ از:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(54, 18);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.dtpTo;
            this.layoutControlItem4.Location = new System.Drawing.Point(812, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(173, 30);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(173, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(173, 32);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "لغایت:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(44, 18);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(306, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(378, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnPrint;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(153, 32);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(153, 32);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(153, 32);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnUpdate;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem6.Location = new System.Drawing.Point(153, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(153, 32);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(153, 32);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(153, 32);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "layoutControlItem5";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // dashboardBackstageViewControl1
            // 
            this.dashboardBackstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.dashboardBackstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.dashboardBackstageViewControl1.DashboardRecentTab = this.dashboardBackstageRecentTab1;
            this.dashboardBackstageViewControl1.Items.Add(this.dashboardBackstageNewButton1);
            this.dashboardBackstageViewControl1.Items.Add(this.dashboardBackstageOpenButton1);
            this.dashboardBackstageViewControl1.Items.Add(this.dashboardBackstageSaveButton1);
            this.dashboardBackstageViewControl1.Items.Add(this.dashboardBackstageSaveAsButton1);
            this.dashboardBackstageViewControl1.Items.Add(this.dashboardBackstageRecentTab1);
            this.dashboardBackstageViewControl1.Location = new System.Drawing.Point(0, 0);
            this.dashboardBackstageViewControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dashboardBackstageViewControl1.Name = "dashboardBackstageViewControl1";
            this.dashboardBackstageViewControl1.SelectedTab = this.dashboardBackstageRecentTab1;
            this.dashboardBackstageViewControl1.SelectedTabIndex = 4;
            this.dashboardBackstageViewControl1.Size = new System.Drawing.Size(280, 185);
            this.dashboardBackstageViewControl1.TabIndex = 2;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.recentDashboardsControl1);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(21, 0);
            this.backstageViewClientControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(127, 185);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // recentDashboardsControl1
            // 
            this.recentDashboardsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentDashboardsControl1.ForeColor = System.Drawing.Color.Transparent;
            this.recentDashboardsControl1.Location = new System.Drawing.Point(0, 0);
            this.recentDashboardsControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.recentDashboardsControl1.Name = "recentDashboardsControl1";
            this.recentDashboardsControl1.ServiceProvider = null;
            this.recentDashboardsControl1.Size = new System.Drawing.Size(127, 185);
            this.recentDashboardsControl1.TabIndex = 0;
            // 
            // dashboardBackstageRecentTab1
            // 
            this.dashboardBackstageRecentTab1.ContentControl = this.backstageViewClientControl1;
            this.dashboardBackstageRecentTab1.Name = "dashboardBackstageRecentTab1";
            this.dashboardBackstageRecentTab1.RecentDashboardsControl = this.recentDashboardsControl1;
            this.dashboardBackstageRecentTab1.Selected = true;
            // 
            // dashboardBackstageNewButton1
            // 
            this.dashboardBackstageNewButton1.Glyph = ((System.Drawing.Image)(resources.GetObject("dashboardBackstageNewButton1.Glyph")));
            this.dashboardBackstageNewButton1.Name = "dashboardBackstageNewButton1";
            this.dashboardBackstageNewButton1.ServiceProvider = null;
            // 
            // dashboardBackstageOpenButton1
            // 
            this.dashboardBackstageOpenButton1.Glyph = ((System.Drawing.Image)(resources.GetObject("dashboardBackstageOpenButton1.Glyph")));
            this.dashboardBackstageOpenButton1.Name = "dashboardBackstageOpenButton1";
            this.dashboardBackstageOpenButton1.ServiceProvider = null;
            // 
            // dashboardBackstageSaveButton1
            // 
            this.dashboardBackstageSaveButton1.Glyph = ((System.Drawing.Image)(resources.GetObject("dashboardBackstageSaveButton1.Glyph")));
            this.dashboardBackstageSaveButton1.Name = "dashboardBackstageSaveButton1";
            this.dashboardBackstageSaveButton1.ServiceProvider = null;
            // 
            // dashboardBackstageSaveAsButton1
            // 
            this.dashboardBackstageSaveAsButton1.Glyph = ((System.Drawing.Image)(resources.GetObject("dashboardBackstageSaveAsButton1.Glyph")));
            this.dashboardBackstageSaveAsButton1.Name = "dashboardBackstageSaveAsButton1";
            this.dashboardBackstageSaveAsButton1.ServiceProvider = null;
            // 
            // frmFDSexDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 662);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dashboardBackstageViewControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFDSexDashboard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "به تفکیک جنسیت";
            this.Load += new System.EventHandler(this.frmFDSexDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBackstageViewControl1)).EndInit();
            this.dashboardBackstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageViewControl dashboardBackstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.DashboardWin.Bars.RecentDashboardsControl recentDashboardsControl1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageRecentTab dashboardBackstageRecentTab1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageNewButton dashboardBackstageNewButton1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageOpenButton dashboardBackstageOpenButton1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageSaveButton dashboardBackstageSaveButton1;
        private DevExpress.DashboardWin.Bars.DashboardBackstageSaveAsButton dashboardBackstageSaveAsButton1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.DashboardWin.DashboardViewer dashboardViewer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private PersianDate.DatePicker dtpTo;
        private PersianDate.DatePicker dtpFrom;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}