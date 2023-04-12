Imports System.Windows.Forms

Public Class dialogEditUser
    Private User As User
    Private _ApplicationName As String
    Public Property ApplicationName() As String
        Get
            If _ApplicationName Is Nothing Then
                Dim appInfo As New ApplicationServices.ApplicationBase
                Return appInfo.Info.AssemblyName
            End If
            Return _ApplicationName
        End Get
        Set(ByVal value As String)
            _ApplicationName = value
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Dim Queries As New DSTableAdapters.QueriesTableAdapter
            If User.Username <> txtUserName.Text Then
                Dim uac As New UserAuthenticationController
                If uac.IsUserExist(txtUserName.Text, ApplicationName) Then
                    MessageBox.Show("نام کاربری وارد شده تکراری می باشد" + vbNewLine + "لطفاً نام کاربری دیگری انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                    Exit Sub
                End If
            End If
            Queries.UpdateUser(txtUserName.Text, txtFirstName.Text, txtLastName.Text, User.Disabled, numPersonalNo.Value, txtDescriptions.Text, User.ApplicationID, User.UserID, cmbSex.SelectedIndex)
            'MessageBox.Show("تغییرات با موفقیت ذخیره گردید","
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal User As User, ByVal ApplicationName As String)
        Me.User = User
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.ApplicationName = ApplicationName

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dialogEditUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserName.Text = User.Username
        txtFirstName.Text = User.FirstName
        txtLastName.Text = User.LastName
        txtDescriptions.Text = User.Descriptions
        numPersonalNo.Value = User.PersonalNo
        cmbSex.SelectedIndex = IIf(User.Sex, 1, 0)
    End Sub
End Class
