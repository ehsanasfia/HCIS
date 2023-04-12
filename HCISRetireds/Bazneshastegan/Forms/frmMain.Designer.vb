<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grdFile = New System.Windows.Forms.DataGridView()
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.پروندهToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.دریافتاطلاعاتToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRetrive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRetriveBastari = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRetriveKharej = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.خواندنفایلToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.خروجToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.گزارشاتToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.فیزیوتراپیToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.مدیریتToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.مدیریتکاربرانToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.چاپToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPersonnelNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colrelationName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVisitDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMedicalService = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPayMent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StiReport1 = New Stimulsoft.Report.StiReport()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.DS = New Bazneshastegan.DS()
        Me.ShowsarpaeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShowsarpaeeTableAdapter = New Bazneshastegan.DSTableAdapters.showsarpaeeTableAdapter()
        Me.colnationalid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.grdFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintableComponentLink1.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShowsarpaeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        '
        'BackgroundWorker1
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 24)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1058, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.Name = "tsStatusLabel"
        Me.tsStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tsStatusLabel.Size = New System.Drawing.Size(77, 17)
        Me.tsStatusLabel.Text = "خوش آمدید"
        '
        'grdFile
        '
        Me.grdFile.AllowUserToAddRows = False
        Me.grdFile.AllowUserToDeleteRows = False
        Me.grdFile.AllowUserToResizeRows = False
        Me.grdFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFile.Location = New System.Drawing.Point(12, 49)
        Me.grdFile.Name = "grdFile"
        Me.grdFile.ReadOnly = True
        Me.grdFile.RowHeadersVisible = False
        Me.grdFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFile.Size = New System.Drawing.Size(1034, 507)
        Me.grdFile.TabIndex = 11
        '
        'mainMenu
        '
        Me.mainMenu.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.پروندهToolStripMenuItem, Me.گزارشاتToolStripMenuItem, Me.مدیریتToolStripMenuItem, Me.چاپToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(1058, 24)
        Me.mainMenu.TabIndex = 13
        Me.mainMenu.Text = "MenuStrip1"
        '
        'پروندهToolStripMenuItem
        '
        Me.پروندهToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.دریافتاطلاعاتToolStripMenuItem, Me.mnuSave, Me.خواندنفایلToolStripMenuItem, Me.خروجToolStripMenuItem})
        Me.پروندهToolStripMenuItem.Name = "پروندهToolStripMenuItem"
        Me.پروندهToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.پروندهToolStripMenuItem.Text = "پرونده"
        '
        'دریافتاطلاعاتToolStripMenuItem
        '
        Me.دریافتاطلاعاتToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRetrive, Me.mnuRetriveBastari, Me.mnuRetriveKharej})
        Me.دریافتاطلاعاتToolStripMenuItem.Name = "دریافتاطلاعاتToolStripMenuItem"
        Me.دریافتاطلاعاتToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.دریافتاطلاعاتToolStripMenuItem.Text = "دریافت اطلاعات بازنشستگان"
        '
        'mnuRetrive
        '
        Me.mnuRetrive.Name = "mnuRetrive"
        Me.mnuRetrive.Size = New System.Drawing.Size(134, 22)
        Me.mnuRetrive.Text = "سرپایی"
        '
        'mnuRetriveBastari
        '
        Me.mnuRetriveBastari.Name = "mnuRetriveBastari"
        Me.mnuRetriveBastari.Size = New System.Drawing.Size(134, 22)
        Me.mnuRetriveBastari.Text = "بستری"
        '
        'mnuRetriveKharej
        '
        Me.mnuRetriveKharej.Name = "mnuRetriveKharej"
        Me.mnuRetriveKharej.Size = New System.Drawing.Size(134, 22)
        Me.mnuRetriveKharej.Text = "خارج از مرکز"
        '
        'mnuSave
        '
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(218, 22)
        Me.mnuSave.Text = "ذخیره اطلاعات"
        '
        'خواندنفایلToolStripMenuItem
        '
        Me.خواندنفایلToolStripMenuItem.Name = "خواندنفایلToolStripMenuItem"
        Me.خواندنفایلToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.خواندنفایلToolStripMenuItem.Text = "خواندن اطلاعات از فایل"
        '
        'خروجToolStripMenuItem
        '
        Me.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem"
        Me.خروجToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.خروجToolStripMenuItem.Text = "خروج"
        '
        'گزارشاتToolStripMenuItem
        '
        Me.گزارشاتToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.فیزیوتراپیToolStripMenuItem})
        Me.گزارشاتToolStripMenuItem.Name = "گزارشاتToolStripMenuItem"
        Me.گزارشاتToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.گزارشاتToolStripMenuItem.Text = "گزارشات"
        '
        'فیزیوتراپیToolStripMenuItem
        '
        Me.فیزیوتراپیToolStripMenuItem.Name = "فیزیوتراپیToolStripMenuItem"
        Me.فیزیوتراپیToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.فیزیوتراپیToolStripMenuItem.Text = "فیزیوتراپی"
        '
        'مدیریتToolStripMenuItem
        '
        Me.مدیریتToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.مدیریتکاربرانToolStripMenuItem})
        Me.مدیریتToolStripMenuItem.Name = "مدیریتToolStripMenuItem"
        Me.مدیریتToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.مدیریتToolStripMenuItem.Text = "مدیریت"
        '
        'مدیریتکاربرانToolStripMenuItem
        '
        Me.مدیریتکاربرانToolStripMenuItem.Name = "مدیریتکاربرانToolStripMenuItem"
        Me.مدیریتکاربرانToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.مدیریتکاربرانToolStripMenuItem.Text = "مدیریت کاربران"
        '
        'چاپToolStripMenuItem
        '
        Me.چاپToolStripMenuItem.Name = "چاپToolStripMenuItem"
        Me.چاپToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.چاپToolStripMenuItem.Text = "چاپ"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.ShowsarpaeeBindingSource
        Me.GridControl1.Location = New System.Drawing.Point(0, 49)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1058, 563)
        Me.GridControl1.TabIndex = 14
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridControl1.Visible = False
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPersonnelNo, Me.colnam, Me.colrelationName, Me.colVisitDate, Me.colname, Me.colMedicalService, Me.colPayMent, Me.colGp, Me.GridColumn1, Me.colnationalid})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colPersonnelNo
        '
        Me.colPersonnelNo.Caption = "شماره پرسنلی"
        Me.colPersonnelNo.FieldName = "PersonnelNo"
        Me.colPersonnelNo.Name = "colPersonnelNo"
        Me.colPersonnelNo.OptionsColumn.AllowEdit = False
        Me.colPersonnelNo.Visible = True
        Me.colPersonnelNo.VisibleIndex = 8
        Me.colPersonnelNo.Width = 89
        '
        'colnam
        '
        Me.colnam.Caption = "نام و نام خانوادگی"
        Me.colnam.FieldName = "nam"
        Me.colnam.Name = "colnam"
        Me.colnam.OptionsColumn.AllowEdit = False
        Me.colnam.OptionsColumn.ReadOnly = True
        Me.colnam.Visible = True
        Me.colnam.VisibleIndex = 7
        Me.colnam.Width = 114
        '
        'colrelationName
        '
        Me.colrelationName.Caption = "نسبت"
        Me.colrelationName.FieldName = "relationName"
        Me.colrelationName.Name = "colrelationName"
        Me.colrelationName.OptionsColumn.AllowEdit = False
        Me.colrelationName.Visible = True
        Me.colrelationName.VisibleIndex = 6
        Me.colrelationName.Width = 57
        '
        'colVisitDate
        '
        Me.colVisitDate.Caption = "تاریخ خدمت"
        Me.colVisitDate.FieldName = "VisitDate"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.OptionsColumn.AllowEdit = False
        Me.colVisitDate.Visible = True
        Me.colVisitDate.VisibleIndex = 5
        Me.colVisitDate.Width = 93
        '
        'colname
        '
        Me.colname.Caption = "خدمت"
        Me.colname.FieldName = "name"
        Me.colname.Name = "colname"
        Me.colname.OptionsColumn.AllowEdit = False
        Me.colname.Visible = True
        Me.colname.VisibleIndex = 3
        Me.colname.Width = 109
        '
        'colMedicalService
        '
        Me.colMedicalService.Caption = "کد خدمت"
        Me.colMedicalService.FieldName = "MedicalService"
        Me.colMedicalService.Name = "colMedicalService"
        Me.colMedicalService.OptionsColumn.AllowEdit = False
        Me.colMedicalService.Visible = True
        Me.colMedicalService.VisibleIndex = 1
        Me.colMedicalService.Width = 69
        '
        'colPayMent
        '
        Me.colPayMent.Caption = "هزینه"
        Me.colPayMent.DisplayFormat.FormatString = "ریال ###,###,###,### "
        Me.colPayMent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPayMent.FieldName = "PayMent"
        Me.colPayMent.Name = "colPayMent"
        Me.colPayMent.OptionsColumn.AllowEdit = False
        Me.colPayMent.Visible = True
        Me.colPayMent.VisibleIndex = 0
        Me.colPayMent.Width = 92
        '
        'colGp
        '
        Me.colGp.Caption = "گروه خدمت"
        Me.colGp.FieldName = "Gp"
        Me.colGp.Name = "colGp"
        Me.colGp.OptionsColumn.AllowEdit = False
        Me.colGp.Visible = True
        Me.colGp.VisibleIndex = 4
        Me.colGp.Width = 114
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ردیف"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 9
        Me.GridColumn1.Width = 35
        '
        'StiReport1
        '
        Me.StiReport1.EngineVersion = Stimulsoft.Report.Engine.StiEngineVersion.EngineV2
        Me.StiReport1.ReferencedAssemblies = New String() {"System.Dll", "System.Drawing.Dll", "System.Windows.Forms.Dll", "System.Data.Dll", "System.Xml.Dll", "Stimulsoft.Controls.Dll", "Stimulsoft.Base.Dll", "Stimulsoft.Report.Dll"}
        Me.StiReport1.ReportAlias = "Report"
        Me.StiReport1.ReportGuid = "904a72bc294d4eab8970e79721ce99b2"
        Me.StiReport1.ReportName = "Report"
        Me.StiReport1.ReportSource = resources.GetString("StiReport1.ReportSource")
        Me.StiReport1.ReportUnit = Stimulsoft.Report.StiReportUnitType.Inches
        Me.StiReport1.ScriptLanguage = Stimulsoft.Report.StiReportLanguageType.VB
        Me.StiReport1.UseProgressInThread = False
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        '
        '
        '
        Me.PrintableComponentLink1.ImageCollection.ImageStream = CType(resources.GetObject("PrintableComponentLink1.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.PrintableComponentLink1.Owner = Nothing
        Me.PrintableComponentLink1.PrintingSystem = Me.PrintingSystem1
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'DS
        '
        Me.DS.DataSetName = "DS"
        Me.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ShowsarpaeeBindingSource
        '
        Me.ShowsarpaeeBindingSource.DataMember = "showsarpaee"
        Me.ShowsarpaeeBindingSource.DataSource = Me.DS
        '
        'ShowsarpaeeTableAdapter
        '
        Me.ShowsarpaeeTableAdapter.ClearBeforeFill = True
        '
        'colnationalid
        '
        Me.colnationalid.Caption = "کد ملی"
        Me.colnationalid.FieldName = "nationalid"
        Me.colnationalid.Name = "colnationalid"
        Me.colnationalid.Visible = True
        Me.colnationalid.VisibleIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 612)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.grdFile)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mainMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سیستم بازنشستگان"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.grdFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintableComponentLink1.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShowsarpaeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents grdFile As System.Windows.Forms.DataGridView
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents پروندهToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents دریافتاطلاعاتToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRetrive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRetriveBastari As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRetriveKharej As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents خروجToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents مدیریتToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents مدیریتکاربرانToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents خواندنفایلToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents گزارشاتToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents فیزیوتراپیToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPersonnelNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colrelationName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVisitDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMedicalService As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPayMent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents چاپToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StiReport1 As Stimulsoft.Report.StiReport
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents DS As Bazneshastegan.DS
    Friend WithEvents ShowsarpaeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShowsarpaeeTableAdapter As Bazneshastegan.DSTableAdapters.showsarpaeeTableAdapter
    Friend WithEvents colnationalid As DevExpress.XtraGrid.Columns.GridColumn

End Class
