Imports System.Windows.Forms

Public Class dialogChangePassword

    Private UserName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not txtPassword.Text = txtPasswordConfirmation.Text Then
            MessageBox.Show("کلمه عبور جدید تایید نشد" + vbCrLf + "کلمه عبور جدید و تایید آن باید یکی باشند", "اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            txtPassword.Text = ""
            txtPasswordConfirmation.Text = ""
            Exit Sub
        End If

        Dim Password(32) As Byte
        Dim uac As New UserAuthenticationController()
        Password = uac.HashString(txtPassword.Text)

        Try
            'DS.tblUsers.Select("UserName = '" + UserName + "'").First.Item("Password") = Password
            'TblUsersTableAdapter.Update(DS.tblUsers)

            Dim dc As SecurityLoginsAndAccessControl.SecurityControlClassesDataContext = New SecurityLoginsAndAccessControl.SecurityControlClassesDataContext()
            For Each usr As tblUser In dc.tblUsers.Where(Function(x) x.UserName = UserName And x.ApplicationID > 1000)
                usr.Password = Password
            Next
            dc.SubmitChanges()

            'TblUsersTableAdapter.FillByUserName_ApplicationName(Me.DS.tblUsers, UserName, "HCIS")
            'If DS.tblUsers.Rows.Count > 0 Then
            '    DS.tblUsers.Select("UserName = '" + UserName + "'").First.Item("Password") = Password
            '    TblUsersTableAdapter.Update(DS.tblUsers)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dialogChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS.tblUsers' table. You can move, or remove it, as needed.
        If UserName = "administrator" Then
            Me.TblUsersTableAdapter.FillByUserName(Me.DS.tblUsers, UserName)
        Else
            Me.TblUsersTableAdapter.FillByUserName_ApplicationName(Me.DS.tblUsers, UserName, ApplicationName)
        End If
        If DS.tblUsers.Rows.Count <= 0 Then
            MessageBox.Show("کاربری با این نام یافت نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Me.Close()
        End If
    End Sub

    Public Sub New(ByVal Username As String, ApplicationName As String)
        Username = Replace(Username, "ي", "ی")
        Username = Username.ToLower
        Me.UserName = Username
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ApplicationName = ApplicationName
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private _ApplicationName As String
    Public Property ApplicationName() As String
        Get
            If _ApplicationName Is Nothing Then
                Return (New ApplicationServices.ApplicationBase).Info.AssemblyName

            End If
            Return _ApplicationName
        End Get
        Set(ByVal value As String)
            _ApplicationName = value
        End Set
    End Property
    Public Sub New(ByVal Username As String)
        Username = Replace(Username, "ي", "ی")
        Username = Username.ToLower
        Me.UserName = Username
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class