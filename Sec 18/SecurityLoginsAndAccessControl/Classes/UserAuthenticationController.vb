Imports System.Text.RegularExpressions
Public Class UserAuthenticationController

    Public Authenticated As Boolean = False
    Public UserName As String, Password As String
    Public Sub New()
        UserName = ""
        Password = ""
    End Sub

    Public Sub New(ByVal usr As String, ByVal pwd As String, ByVal AppName As String)
        UserName = usr.ToLower
        Password = pwd
        AuthenticateUser()
    End Sub

    Public Sub AuthenticateUser()
        Dim Queries As New DSTableAdapters.QueriesTableAdapter
        Dim appInfo As New ApplicationServices.ApplicationBase
        If UserName.Length <= 0 Then
            MessageBox.Show("نام کاربری نمی تواند خالی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If
        UserName = Replace(UserName, "ي", "ی")
        UserName = UserName.ToLower
        Dim UserID As Integer
        If UserName = "administrator" Then
            UserID = Val(Queries.UserAuthenticationWAdminModeSupport(UserName, HashString(Password), appInfo.Info.AssemblyName, 1))
        Else
            UserID = Val(Queries.UserAuthentication(UserName, HashString(Password), appInfo.Info.AssemblyName))
        End If

        If UserID > 0 Then
            Authenticated = True
        Else : Authenticated = False
        End If

    End Sub

    Public Function HashString(ByVal str As String) As Byte()
        Dim Encoder As New System.Text.UTF8Encoding
        Dim Hasher As New System.Security.Cryptography.SHA256Managed
        Dim Result(32) As Byte
        Result = Hasher.ComputeHash(Encoder.GetBytes(str))
        Return Result
    End Function

    Public Function CreateUser(ByVal Username As String, ByVal Password As String, ByVal Firstname As String, ByVal Lastname As String, ByVal Disabled As Boolean, ByVal PersonalNo As Integer, ByVal Descriptions As String, ByVal Sex As Boolean) As Boolean
        Dim appInfo As New ApplicationServices.ApplicationBase
        Return CreateUser(Username, Password, Firstname, Lastname, Disabled, appInfo.Info.AssemblyName, PersonalNo, Descriptions, Sex)
    End Function

    Public Function CreateUser(ByVal Username As String, ByVal Password As String, ByVal Firstname As String, ByVal Lastname As String, ByVal Disabled As Boolean, ByVal ApplicationName As String, ByVal PersonalNo As Integer, ByVal Descriptions As String, ByVal Sex As Boolean) As Boolean
        Dim Result As Boolean = False
        Username = Replace(Username, "ي", "ی")
        Username = Username.ToLower
        If IsUserExist(Username, ApplicationName) Then
            MessageBox.Show("این نام کاربری قبلاً ایجاد شده است،لطفاً نام کاربری دیگری انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Function
            'ElseIf IsUserExist(Username) Then
            '    If Not MessageBox.Show("این نام کاربری جهت استفاده از دیگر نرم افزارها ایجاد شده است" + vbCrLf + "در صورت ادامه،اطلاعات مربوط  به نام کاربری موجود در سیستم" + vbCrLf + "برای این کاربر وارد می شوند،آیا مایل به ادامه هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = DialogResult.Yes Then
            '        MessageBox.Show("لطفاً نام کاربری دیگری انتخاب کنید", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            '        Exit Function
            '    End If
        End If
        Try
            Dim Queries As New DSTableAdapters.QueriesTableAdapter
            If Username.Length <= 0 Then
                MessageBox.Show("نام کاربری نمی تواند خالی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Result = False
            Else
                Queries.CreateUser(Username, HashString(Password), Firstname, Lastname, Disabled, ApplicationName, PersonalNo, Descriptions, Sex)
                Result = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Result = False
        End Try
        Return Result
    End Function

    Public Function IsUserExist(ByVal Username As String) As Boolean
        Return IsUserExist(Username, (New ApplicationServices.ApplicationBase).Info.AssemblyName)
    End Function

    Public Function IsUserExist(ByVal Username As String, ByVal ApplicationName As String) As Boolean
        Dim Queries As New DSTableAdapters.QueriesTableAdapter
        Dim result As Boolean = False
        Username = Replace(Username, "ي", "ی")
        Username = Username.ToLower
        Try
            Dim a = Queries.func_CheckExistingUser(Username, ApplicationName)
            If Queries.func_CheckExistingUser(Username, ApplicationName) > 0 Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            result = False
        End Try
        Return result
    End Function

End Class
