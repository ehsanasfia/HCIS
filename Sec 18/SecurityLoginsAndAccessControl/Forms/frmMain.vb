Public Class frmMain
    Public upc As UserPermissionsController
    Dim appInfo As New ApplicationServices.ApplicationBase
    Dim dialogLogin As New dialogLogin
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        If Not dialogLogin.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Application.Exit()
        End If
        Me.Show()
        Me.BringToFront()
        upc = New UserPermissionsController(dialogLogin.UserName, appInfo.Info.AssemblyName)
        upc.GetMenuPermissions(MenuStrip1, MyClass.Name)
        'TODO: This line of code loads data into the 'DS.tblApplications' table. You can move, or remove it, as needed.
        Me.TblApplicationsTableAdapter.Fill(Me.DS.tblApplications)
        'TODO: This line of code loads data into the 'DS.tblObjects' table. You can move, or remove it, as needed.
        Me.TblObjectsTableAdapter.Fill(Me.DS.tblObjects)
    End Sub

    Private Sub btnManageUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageUsers.Click, منوی4ToolStripMenuItem.Click
        Dim frmMngUsrs As New frmManageUsers(dialogLogin.UserName, appInfo.Info.AssemblyName, MenuStrip1)
        frmMngUsrs.BringToFront()
        frmMngUsrs.ShowDialog()
        upc = New UserPermissionsController(dialogLogin.UserName, appInfo.Info.AssemblyName)
        upc.GetMenuPermissions(MenuStrip1, MyClass.Name)
    End Sub
End Class
