Imports System.Windows.Forms

Public Class dialogPrint2
    Public reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If Not Me.DialogResult = System.Windows.Forms.DialogResult.OK Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        CrystalReportViewer1.PrintReport()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub dialogClinicalOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        CrystalReportViewer1.ReportSource = reportDocument
        btnPrint.Select()
        btnPrint.Focus()
    End Sub

    Public Sub New(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        reportDocument = rpt
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
