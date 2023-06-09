Public Class dialogLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Public UserName As String, User As User, ApplicationDepartmentID As Short, ApplicationDepartmentName As String
    Private OriginalKeyLayout As InputLanguage
    Public Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is DevExpress.XtraEditors.PictureEdit Or TypeOf ctrl Is DevExpress.XtraEditors.LabelControl Then AddHandler ctrl.MouseDown, AddressOf MouseDownEvent
        Next
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If txtUserName.Text.Length > 0 Then
                Dim appinfo As New ApplicationServices.ApplicationBase
                Dim uac As New UserAuthenticationController(txtUserName.Text, txtPassword.Text, appinfo.Info.AssemblyName)
                If uac.Authenticated Then

                    Me.UserName = uac.UserName
                    User = New User(uac.UserName)

                    Dim builder As New System.Data.SqlClient.SqlConnectionStringBuilder
                    builder.ConnectionString = My.Settings.Item("SecurityControlConnectionString")
                    builder.ApplicationName = String.Format("User:{0}, UserID:{1}, ApplicationName:{2}", User.Username, User.UserID, appinfo.Info.AssemblyName)
                    If builder.ApplicationName.Length > 128 Then
                        builder.ApplicationName = builder.ApplicationName.Substring(0, 128)
                    End If
                    My.Settings.Item("SecurityControlConnectionString") = builder.ConnectionString

                    builder.ConnectionString = My.Settings.Item("HospitalConnectionString")
                    builder.ApplicationName = String.Format("User:{0}, UserID:{1}, ApplicationName:{2}", User.Username, User.UserID, appinfo.Info.AssemblyName)
                    If builder.ApplicationName.Length > 128 Then
                        builder.ApplicationName = builder.ApplicationName.Substring(0, 128)
                    End If
                    My.Settings.Item("HospitalConnectionString") = builder.ConnectionString

                    'Dim diag As New dialogChooseApplication(User)
                    'diag.BringToFront()
                    'Me.Hide()
                    'Me.DialogResult = diag.ShowDialog()
                    'ApplicationDepartmentID = diag.ChoosenDepartment
                    'ApplicationDepartmentName = diag.ChoosenDepartmentName
                    DialogResult = DialogResult.OK
                    Me.Close()
                Else : MessageBox.Show("نام کاربر یا کلمه عبور اشتباه می باشد لطفاً اطلاعات وارده را دوباره چک کنید" + vbCrLf + "در صورتیکه نام کاربری شما غیر فعال می باشد فعال سازی آن را می بایست از مدیر سیستم درخواست کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                End If
            Else : MessageBox.Show("نام وارد نشده است" + vbCrLf + "لطفاً نام کاربری را وارد نمایید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            End If
        Catch ex As SqlClient.SqlException
            If ex.Message Like "?server was not found?" Then
                MessageBox.Show("خطا در اتصال به سرور" + vbCrLf + "لطفاً با مدیر سیستم تماس بگیرید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Else
                MessageBox.Show(ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dialogLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        InputLanguage.CurrentInputLanguage = OriginalKeyLayout
    End Sub


    Private Sub MouseDownEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            CType(sender, Control).Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1S
            Const HTCAPTION As Integer = 2
            Dim msg As Message =
                Message.Create(Me.Handle, WM_NCLBUTTONDOWN,
                    New IntPtr(HTCAPTION), IntPtr.Zero)
            Me.DefWndProc(msg)
        End If
    End Sub

    Private Sub dialogLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LookAndFeel.Assign(StyleController1.LookAndFeel)
        If Not My.Computer.Keyboard.NumLock Then My.Computer.Keyboard.SendKeys("{NUMLOCK}")
        OriginalKeyLayout = InputLanguage.CurrentInputLanguage
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New Globalization.CultureInfo("en-US"))
        Activate()
    End Sub

    Private Sub txtUserName_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.Controls(CStr(CType(sender, DevExpress.XtraEditors.TextEdit).Tag)), DevExpress.XtraEditors.LabelControl).Font = New Font("Tahoma", 9.75, FontStyle.Bold)
    End Sub

    Private Sub txtUserName_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.Controls(CStr(CType(sender, DevExpress.XtraEditors.TextEdit).Tag)), DevExpress.XtraEditors.LabelControl).Font = New Font("Tahoma", 9.75, FontStyle.Regular)
    End Sub
End Class


