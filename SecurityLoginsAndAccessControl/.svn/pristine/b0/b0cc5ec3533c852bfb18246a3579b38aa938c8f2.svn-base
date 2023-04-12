Public Class frmManageUsersOLD

#Region "Variable Declarations"

    Private CurrentUser As String, ApplicationName As String, MenuContainerClass As String
    Private MainMenu As MenuStrip
    Private upc As UserPermissionsController
    Private UserOption() As String, HasOption As Boolean
#End Region

#Region "Initializations"


    Public Sub New(ByVal username As String, ByVal className As String, ByVal mnu As MenuStrip, ByVal appName As String, ByVal OptionParameter() As String)
        CurrentUser = username
        ApplicationName = appName
        MenuContainerClass = className
        MainMenu = mnu
        HasOption = CBool(IIf(IsNothing(OptionParameter), False, True))
        UserOption = OptionParameter
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal username As String, ByVal className As String, ByVal mnu As MenuStrip, ByVal OptionParameter() As String)
        Me.New(username, className, mnu, (New ApplicationServices.ApplicationBase).Info.AssemblyName, OptionParameter)
    End Sub

    Public Sub New(ByVal username As String, ByVal className As String, ByVal mnu As MenuStrip, ByVal appName As String)
        Me.New(username, className, mnu, appName, Nothing)
    End Sub

    Public Sub New(ByVal username As String, ByVal className As String, ByVal mnu As MenuStrip)
        Me.New(username, className, mnu, (New ApplicationServices.ApplicationBase).Info.AssemblyName, Nothing)
    End Sub

    Private Sub frmManageUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS.tblApplicationDepartments' table. You can move, or remove it, as needed.
        Me.TblApplicationDepartmentsTableAdapter.FillbyApplicationName(Me.DS.tblApplicationDepartments, ApplicationName)
        If DS.tblApplicationDepartments.Rows.Count <= 0 Then
            btnManageUserApplication.Visible = False
            دسترسیبهنرمافزارهاToolStripMenuItem.Visible = False
        End If
        upc = New UserPermissionsController(CurrentUser, ApplicationName)
        upc.AddMenu(MainMenu, MenuContainerClass)
        'TODO: This line of code loads data into the 'DS.tblUsers' table. You can move, or remove it, as needed.
        Me.TblUsersTableAdapter.FillByAppID(Me.DS.tblUsers, upc.AppID)

        حذفکاربرToolStripMenuItem.Visible = btnRemoveUser.Visible
    End Sub
#End Region

#Region "Menu Clicks"


    Private Sub فعالسازیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles فعالسازیToolStripMenuItem.Click
        If TblUsersBindingSource.Position >= 0 Then
            DS.tblUsers.Select("UserID = " + CType(TblUsersBindingSource.Current, DataRowView)("UserID").ToString()).First.Item("Disabled") = IIf(فعالسازیToolStripMenuItem.Text = "فعال سازی", False, True)
            TblUsersTableAdapter.Update(DS.tblUsers)
            MessageBox.Show("کاربر با موفقیت " + IIf(فعالسازیToolStripMenuItem.Text = "فعال سازی", "فعال سازی", "غیر فعال").ToString() + " شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        End If
    End Sub

    Private Sub کاربرجدیدToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles کاربرجدیدToolStripMenuItem.Click
        btnNewUser_Click(Nothing, Nothing)
    End Sub

    Private Sub تغییرکلمهعبورToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تغییرکلمهعبورToolStripMenuItem.Click
        btnChangePassword_Click(Nothing, Nothing)
    End Sub

    Private Sub تعیینسطحدسترسیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تعیینسطحدسترسیToolStripMenuItem.Click
        btnChangePermissions_Click(Nothing, Nothing)
    End Sub

    Private Sub حذفکاربرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles حذفکاربرToolStripMenuItem.Click
        btnRemoveUser_Click(Nothing, Nothing)
    End Sub

    Private Sub ویرایشکاربرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ویرایشکاربرToolStripMenuItem.Click
        btnEditUser_Click(Nothing, Nothing)
    End Sub

    Private Sub دسترسیبهنرمافزارهاToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles دسترسیبهنرمافزارهاToolStripMenuItem.Click
        btnManageUserApplication_Click(sender, e)
    End Sub
#End Region

#Region "Button Clicks"


    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If TblUsersBindingSource.Position >= 0 Then
            Dim currentRow As DataRowView = CType(TblUsersBindingSource.Current, DataRowView)
            Dim diag As New dialogChangePassword(currentRow("UserName"))
            diag.ShowDialog()
        End If
    End Sub

    Private Sub btnNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Dim diag As dialogNewUser
        If HasOption Then
            diag = New dialogNewUser(True, UserOption)
        Else : diag = New dialogNewUser()
        End If
        If diag.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim dialogPassword As New dialogChangePassword(diag.txtUserName.Text)
            If dialogPassword.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim upc As New UserPermissionsController(diag.txtUserName.Text, ApplicationName)
                Dim dialogPermission As New dialogPermissionCreator(upc, MenuContainerClass)
                upc.CopyDropDownItems(MainMenu, dialogPermission.mnuMainMenu, True)
                upc.GetMenuPermissions(dialogPermission.mnuMainMenu, MenuContainerClass, True)
                dialogPermission.ShowDialog()
            End If
            TblUsersTableAdapter.FillByAppID(DS.tblUsers, upc.AppID)
        End If
    End Sub

    Private Sub btnChangePermissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePermissions.Click
        If TblUsersBindingSource.Position >= 0 Then
            Dim currentUser As DataRowView
            currentUser = CType(TblUsersBindingSource.Current, DataRowView)
            upc = New UserPermissionsController(currentUser("UserName"), ApplicationName)
            Dim dialogChangePermissions As New dialogPermissionCreator(upc, MenuContainerClass)
            upc.CopyDropDownItems(MainMenu, dialogChangePermissions.mnuMainMenu, True)
            upc.GetMenuPermissions(dialogChangePermissions.mnuMainMenu, MenuContainerClass, True)
            If dialogChangePermissions.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("تغییرات با موفقیت ثبت گردید", "تغییر سطح دسترسی", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            End If
        End If
    End Sub

    Private Sub btnRemoveUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveUser.Click
        If TblUsersBindingSource.Position >= 0 Then
            If MessageBox.Show("در صورت حذف هیچ امکانی برای بازگشت آن وجود نخواهد داشت" + vbCrLf + "آیا از حذف این کاربر اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.Yes Then
                TblUsersBindingSource.RemoveCurrent()
                TblUsersTableAdapter.Update(DS.tblUsers)
            End If
        End If
    End Sub

    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        Try
            If TblUsersBindingSource.Position >= 0 Then
                Dim diag As New dialogEditUser(New User(CType(TblUsersBindingSource.Current, DataRowView)("UserName"), ApplicationName))
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    TblUsersTableAdapter.FillByApplicationName(DS.tblUsers, ApplicationName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnManageUserApplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageUserApplication.Click
        If TblUsersBindingSource.Position >= 0 Then
            Dim diag As New dialogChooseUserDepartments(New User(CType(TblUsersBindingSource.Current, DataRowView)("UserName"), ApplicationName))
            diag.ShowDialog()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
#End Region

#Region "Others"


    Private Sub SetFilter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged, txtLastName.TextChanged, txtFirstName.TextChanged
        TblUsersBindingSource.Filter = "UserName Like '%" + txtUserName.Text + "%' AND FirstName Like '%" + txtFirstName.Text + _
                                        "%' AND LastName Like '%" + txtLastName.Text + "%'"
    End Sub

    Private Sub cMnu1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cMnu1.Opening
        If TblUsersBindingSource.Position >= 0 Then
            If CBool(CType(TblUsersBindingSource.Current, DataRowView)("Disabled")) Then
                فعالسازیToolStripMenuItem.Text = "فعال سازی"
            Else
                فعالسازیToolStripMenuItem.Text = "غیرفعال سازی"
            End If
        End If
    End Sub

    Private Sub grdMngUsers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMngUsers.CellDoubleClick
        btnChangePermissions_Click(Nothing, Nothing)
    End Sub
#End Region

End Class