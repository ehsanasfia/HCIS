namespace HCISCash.Forms
{
    partial class RptDrugEzami
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptDrugEzami));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.txtFrom = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Report = new Stimulsoft.Report.StiReport();
            this.stiAnest = new Stimulsoft.Report.StiReport();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSearch});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(946, 143);
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "داروهای اعزامی خاص";
            this.bbiSearch.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSearch.Glyph")));
            this.bbiSearch.Id = 1;
            this.bbiSearch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSearch.LargeGlyph")));
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "داروهای اعزامی خاص";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "داروهای اعزامی خاص";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.stiViewerControl1);
            this.layoutControl1.Controls.Add(this.txtTo);
            this.layoutControl1.Controls.Add(this.txtFrom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 143);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.MoveFocusRightToLeft = true;
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(946, 353);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.AllowDrop = true;
            this.stiViewerControl1.AutoSize = true;
            this.stiViewerControl1.Location = new System.Drawing.Point(12, 42);
            this.stiViewerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.PageViewMode = Stimulsoft.Report.Viewer.StiPageViewMode.Continuous;
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowCloseButton = false;
            this.stiViewerControl1.ShowEditor = false;
            this.stiViewerControl1.ShowOpen = false;
            this.stiViewerControl1.ShowPageDelete = false;
            this.stiViewerControl1.ShowPageNew = false;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(922, 299);
            this.stiViewerControl1.TabIndex = 157;
            // 
            // txtTo
            // 
            this.txtTo.EnterMoveNextControl = true;
            this.txtTo.Location = new System.Drawing.Point(451, 15);
            this.txtTo.MenuManager = this.ribbon;
            this.txtTo.Name = "txtTo";
            this.txtTo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTo.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtTo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTo.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtTo.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.txtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTo.Size = new System.Drawing.Size(198, 20);
            this.txtTo.StyleController = this.layoutControl1;
            this.txtTo.TabIndex = 5;
            // 
            // txtFrom
            // 
            this.txtFrom.EnterMoveNextControl = true;
            this.txtFrom.Location = new System.Drawing.Point(701, 15);
            this.txtFrom.MenuManager = this.ribbon;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFrom.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.txtFrom.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFrom.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.txtFrom.Properties.Mask.EditMask = "1[34][0-9][0-9]\\/((1[0-2])|(0[1-9]))\\/(([12][0-9])|(3[01])|0[1-9])";
            this.txtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtFrom.Size = new System.Drawing.Size(190, 20);
            this.txtFrom.StyleController = this.layoutControl1;
            this.txtFrom.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(946, 353);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(686, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(240, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "ازتاریخ :";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(436, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(250, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "تا تاریخ :";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.stiViewerControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(926, 303);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(436, 30);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(HCISCash.Data.Department);
            // 
            // Report
            // 
            this.Report.CookieContainer = null;
            this.Report.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.Report.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.Report.ReportAlias = "Report";
            this.Report.ReportGuid = "8cfb96be9549476d8103033500c3040c";
            this.Report.ReportImage = null;
            this.Report.ReportName = "Report";
            this.Report.ReportSource = resources.GetString("Report.ReportSource");
            this.Report.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.Report.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.Report.UseProgressInThread = false;
            // 
            // stiAnest
            // 
            this.stiAnest.CookieContainer = null;
            this.stiAnest.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2;
            this.stiAnest.ReferencedAssemblies = new string[] {
        "System.Dll",
        "System.Drawing.Dll",
        "System.Windows.Forms.Dll",
        "System.Data.Dll",
        "System.Xml.Dll",
        "Stimulsoft.Controls.Dll",
        "Stimulsoft.Base.Dll",
        "Stimulsoft.Report.Dll"};
            this.stiAnest.ReportAlias = "Report";
            this.stiAnest.ReportGuid = "f4ec00b3244543d1b201e244c87358f7";
            this.stiAnest.ReportImage = null;
            this.stiAnest.ReportName = "Report";
            this.stiAnest.ReportSource = resources.GetString("stiAnest.ReportSource");
            this.stiAnest.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches;
            this.stiAnest.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.CSharp;
            this.stiAnest.UseProgressInThread = false;
            // 
            // RptBazneshasteBastariBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 496);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "RptBazneshasteBastariBilling";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "داروهای اعزامی خاص";
            this.Load += new System.EventHandler(this.RptKhadamatTashkhisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTo;
        private DevExpress.XtraEditors.TextEdit txtFrom;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Stimulsoft.Report.StiReport Report;
        private Stimulsoft.Report.StiReport stiAnest;
        private System.Windows.Forms.BindingSource departmentBindingSource;
    }
}