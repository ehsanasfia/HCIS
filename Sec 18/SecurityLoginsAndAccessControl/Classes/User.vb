﻿Public Class User
    Public ReadOnly UserID As Integer, Username As String, FirstName As String, LastName As String, PersonalNo As Integer, Disabled As Boolean, Descriptions As String, ApplicationID As Integer, Sex As Boolean
    Private localDS As DS, dta As DSTableAdapters.tblUsersTableAdapter
    Private _UserConfigDS As UserConfigDS
    Public Sub New(ByVal UserName As String)
        Me.New(UserName, (New ApplicationServices.ApplicationBase).Info.AssemblyName)
    End Sub
    Public Sub New(ByVal UserName As String, ByVal ApplicationName As String)
        UserName = Replace(UserName, "ي", "ی")
        UserName = UserName.ToLower
        Try
            _UserConfigDS = New UserConfigDS
            localDS = New DS
            dta = New DSTableAdapters.tblUsersTableAdapter
            If UserName = "administrator" Then
                dta.FillByUserName(localDS.tblUsers, UserName)
            Else
                dta.FillByUserName_ApplicationName(localDS.tblUsers, UserName, ApplicationName)
            End If
            If localDS.tblUsers.Rows.Count > 0 Then
                Dim userRow As DS.tblUsersRow


                userRow = localDS.tblUsers.Rows(0)
                FirstName = userRow.FirstName
                LastName = userRow.LastName
                Me.Username = userRow.UserName
                UserID = userRow.UserID
                PersonalNo = userRow.PersonalNo
                Disabled = userRow.Disabled
                Descriptions = userRow.Descriptions
                ApplicationID = userRow.ApplicationID
                Sex = userRow.Sex
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function DBNullValue(ByVal obj As String) As String
        If IsDBNull(obj) Then
            Return ""
        Else : Return obj
        End If
    End Function

    Private Sub UpdateUserConfig()
        If localDS.tblUsers.Rows.Count > 0 Then
            Dim UserRow As DS.tblUsersRow = localDS.tblUsers.First
            Dim Str As New System.Text.StringBuilder(10000, 1000000)
            Dim xmlWriter = Xml.XmlWriter.Create(Str)
            _UserConfigDS.tblUserConfigurations.WriteXml(xmlWriter)
            UserRow.SystemDescriptions = Str.ToString
            Try
                dta.Update(localDS.tblUsers)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Property UserConfig() As UserConfigDS.tblUserConfigurationsRow
        Get
            If localDS.tblUsers.Rows.Count <= 0 Or localDS.tblUsers.First.SystemDescriptions Is Nothing Then
                _UserConfigDS.tblUserConfigurations.AddtblUserConfigurationsRow(_UserConfigDS.tblUserConfigurations.NewRow)
            Else
                Dim reader As System.IO.TextReader = New System.IO.StringReader(localDS.tblUsers.First.SystemDescriptions)
                _UserConfigDS.tblUserConfigurations.Clear()
                _UserConfigDS.ReadXml(reader)
            End If
            Return _UserConfigDS.tblUserConfigurations.First
        End Get
        Set(ByVal value As UserConfigDS.tblUserConfigurationsRow)
            '_UserConfigDS.tblUserConfigurations.First.SkinName = value.SkinName
            '_UserConfigDS.tblUserConfigurations.First.Font = value.Font
            '_UserConfigDS.tblUserConfigurations.First.FontSize = value.FontSize
            'If localDS.tblUsers.Rows.Count > 0 Then
            '    Dim UserRow As DS.tblUsersRow = localDS.tblUsers.First
            '    Dim Str As New System.Text.StringBuilder(10000, 1000000)
            '    Dim xmlWriter = Xml.XmlWriter.Create(Str)
            '    _UserConfigDS.tblUserConfigurations.WriteXml(xmlWriter)
            '    UserRow.SystemDescriptions = Str.ToString
            '    Try
            '        dta.Update(localDS.tblUsers)
            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End Try
            'End If
        End Set
    End Property

    Public Property SkinName() As String
        Get
            Return UserConfig.SkinName
        End Get
        Set(ByVal value As String)
            Dim UserRow As UserConfigDS.tblUserConfigurationsRow = UserConfig
            UserRow.SkinName = value
            UpdateUserConfig()
        End Set
    End Property

    Public Property Font() As String
        Get
            Return UserConfig.Font
        End Get
        Set(ByVal value As String)
            Dim UserRow As UserConfigDS.tblUserConfigurationsRow = UserConfig
            UserRow.Font = value
            UpdateUserConfig()
        End Set
    End Property

    Public Property FontSize() As Decimal
        Get
            Return UserConfig.FontSize
        End Get
        Set(ByVal value As Decimal)
            Dim UserRow As UserConfigDS.tblUserConfigurationsRow = UserConfig
            UserRow.FontSize = value
            UpdateUserConfig()
        End Set
    End Property

    Public Property FontStyle()
        Get
            Return UserConfig.FontStyle
        End Get
        Set(ByVal value)
            Dim UserRow As UserConfigDS.tblUserConfigurationsRow = UserConfig
            UserRow.FontStyle = value
            UpdateUserConfig()
        End Set
    End Property
End Class