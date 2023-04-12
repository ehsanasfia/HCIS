Public Class dialogNewUser
    Private Options() As String, HasOption As Boolean
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


    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim uac As New UserAuthenticationController
        If txtUserName.Text.Length > 0 Then
            If txtFirstName.Text.Length > 0 Or txtLastName.Text.Length > 0 Then
                If uac.IsUserExist(txtUserName.Text, ApplicationName) Then
                    MessageBox.Show("نام کاربری وارد شده تکراری می باشد" + vbNewLine + "لطفاً نام کاربری دیگری انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                    Exit Sub
                End If
                If uac.CreateUser(txtUserName.Text, "", txtFirstName.Text, txtLastName.Text, chkDisabled.Checked, ApplicationName, numPersonalNo.Value, txtDescriptions.Text, cmbSex.SelectedIndex) Then
                    'If HasOption Then
                    '    Dim Conn As New SqlClient.SqlConnection(My.Settings.SecurityControlConnectionString)
                    '    Dim Cmd As New SqlClient.SqlCommand(Options(4), Conn)
                    '    Cmd.CommandType = CommandType.StoredProcedure
                    '    Cmd.Parameters.Add("@Par1", SqlDbType.Int)
                    '    Cmd.Parameters.Add("@Par2", SqlDbType.Int)

                    'End If
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                MessageBox.Show("نام و یا نام خانوادگی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            End If
        Else : MessageBox.Show("نام کاربری نمی تواند خالی باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub dialogNewUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSex.SelectedIndex = 0
        'If HasOption Then
        '    chkOption.Text = Options(0)
        '    chkOption.Visible = True
        '    Dim dta As New SqlClient.SqlDataAdapter(Options(1), Options(2))
        '    Dim ds As New DataSet
        '    ds.Tables.Add("tbl")
        '    dta.Fill(ds.Tables("tbl"))
        '    cmbOptionSelection.DataSource = ds.Tables("tbl")
        '    cmbOptionSelection.ValueMember = ds.Tables("tbl").Columns(0).ColumnName
        '    cmbOptionSelection.DisplayMember = ds.Tables("tbl").Columns(1).ColumnName
        '    cmbOptionSelection.Left = chkOption.Left + chkOption.Width + 10
        '    cmbOptionSelection.Width = Me.Width - cmbOptionSelection.Left - 20
        '    cmbOptionSelection.Visible = True
        'End If
    End Sub

    Public Sub New(ByVal HasOption As Boolean, ByVal Options() As String)
        Me.HasOption = HasOption
        Me.Options = Options
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal HasOption As Boolean, ByVal Options() As String, ByVal ApplicationName As String)
        Me.HasOption = HasOption
        Me.Options = Options
        Me.ApplicationName = ApplicationName

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New()
        Me.New(False, Nothing)
    End Sub
End Class