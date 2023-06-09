﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="SecurityControl")>  _
Partial Public Class SecurityControlClassesDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InserttblApplication(instance As tblApplication)
    End Sub
  Partial Private Sub UpdatetblApplication(instance As tblApplication)
    End Sub
  Partial Private Sub DeletetblApplication(instance As tblApplication)
    End Sub
  Partial Private Sub InserttblUser(instance As tblUser)
    End Sub
  Partial Private Sub UpdatetblUser(instance As tblUser)
    End Sub
  Partial Private Sub DeletetblUser(instance As tblUser)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.SecurityLoginsAndAccessControl.My.MySettings.Default.SecurityControlConnectionString1, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property tblApplications() As System.Data.Linq.Table(Of tblApplication)
		Get
			Return Me.GetTable(Of tblApplication)
		End Get
	End Property
	
	Public ReadOnly Property tblUsers() As System.Data.Linq.Table(Of tblUser)
		Get
			Return Me.GetTable(Of tblUser)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblApplications")>  _
Partial Public Class tblApplication
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _ApplicationID As Integer
	
	Private _ApplicationName As String
	
	Private _Description As String
	
	Private _tblUsers As EntitySet(Of tblUser)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnApplicationIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnApplicationIDChanged()
    End Sub
    Partial Private Sub OnApplicationNameChanging(value As String)
    End Sub
    Partial Private Sub OnApplicationNameChanged()
    End Sub
    Partial Private Sub OnDescriptionChanging(value As String)
    End Sub
    Partial Private Sub OnDescriptionChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._tblUsers = New EntitySet(Of tblUser)(AddressOf Me.attach_tblUsers, AddressOf Me.detach_tblUsers)
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ApplicationID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property ApplicationID() As Integer
		Get
			Return Me._ApplicationID
		End Get
		Set
			If ((Me._ApplicationID = value)  _
						= false) Then
				Me.OnApplicationIDChanging(value)
				Me.SendPropertyChanging
				Me._ApplicationID = value
				Me.SendPropertyChanged("ApplicationID")
				Me.OnApplicationIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ApplicationName", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property ApplicationName() As String
		Get
			Return Me._ApplicationName
		End Get
		Set
			If (String.Equals(Me._ApplicationName, value) = false) Then
				Me.OnApplicationNameChanging(value)
				Me.SendPropertyChanging
				Me._ApplicationName = value
				Me.SendPropertyChanged("ApplicationName")
				Me.OnApplicationNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Description", DbType:="NVarChar(MAX)")>  _
	Public Property Description() As String
		Get
			Return Me._Description
		End Get
		Set
			If (String.Equals(Me._Description, value) = false) Then
				Me.OnDescriptionChanging(value)
				Me.SendPropertyChanging
				Me._Description = value
				Me.SendPropertyChanged("Description")
				Me.OnDescriptionChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="tblApplication_tblUser", Storage:="_tblUsers", ThisKey:="ApplicationID", OtherKey:="ApplicationID")>  _
	Public Property tblUsers() As EntitySet(Of tblUser)
		Get
			Return Me._tblUsers
		End Get
		Set
			Me._tblUsers.Assign(value)
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
	
	Private Sub attach_tblUsers(ByVal entity As tblUser)
		Me.SendPropertyChanging
		entity.tblApplication = Me
	End Sub
	
	Private Sub detach_tblUsers(ByVal entity As tblUser)
		Me.SendPropertyChanging
		entity.tblApplication = Nothing
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.tblUsers")>  _
Partial Public Class tblUser
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _UserID As Integer
	
	Private _UserName As String
	
	Private _Password As System.Data.Linq.Binary
	
	Private _FirstName As String
	
	Private _LastName As String
	
	Private _Disabled As Boolean
	
	Private _PersonalNo As System.Nullable(Of Integer)
	
	Private _Descriptions As String
	
	Private _ApplicationID As System.Nullable(Of Integer)
	
	Private _SystemDescriptions As String
	
	Private _Sex As System.Nullable(Of Boolean)
	
	Private _IsNurse As System.Nullable(Of Boolean)
	
	Private _shshGroup As String
	
	Private _RoleID As System.Nullable(Of Integer)
	
	Private _tblApplication As EntityRef(Of tblApplication)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnUserIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnUserIDChanged()
    End Sub
    Partial Private Sub OnUserNameChanging(value As String)
    End Sub
    Partial Private Sub OnUserNameChanged()
    End Sub
    Partial Private Sub OnPasswordChanging(value As System.Data.Linq.Binary)
    End Sub
    Partial Private Sub OnPasswordChanged()
    End Sub
    Partial Private Sub OnFirstNameChanging(value As String)
    End Sub
    Partial Private Sub OnFirstNameChanged()
    End Sub
    Partial Private Sub OnLastNameChanging(value As String)
    End Sub
    Partial Private Sub OnLastNameChanged()
    End Sub
    Partial Private Sub OnDisabledChanging(value As Boolean)
    End Sub
    Partial Private Sub OnDisabledChanged()
    End Sub
    Partial Private Sub OnPersonalNoChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPersonalNoChanged()
    End Sub
    Partial Private Sub OnDescriptionsChanging(value As String)
    End Sub
    Partial Private Sub OnDescriptionsChanged()
    End Sub
    Partial Private Sub OnApplicationIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnApplicationIDChanged()
    End Sub
    Partial Private Sub OnSystemDescriptionsChanging(value As String)
    End Sub
    Partial Private Sub OnSystemDescriptionsChanged()
    End Sub
    Partial Private Sub OnSexChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OnSexChanged()
    End Sub
    Partial Private Sub OnIsNurseChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OnIsNurseChanged()
    End Sub
    Partial Private Sub OnshshGroupChanging(value As String)
    End Sub
    Partial Private Sub OnshshGroupChanged()
    End Sub
    Partial Private Sub OnRoleIDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnRoleIDChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		Me._tblApplication = CType(Nothing, EntityRef(Of tblApplication))
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property UserID() As Integer
		Get
			Return Me._UserID
		End Get
		Set
			If ((Me._UserID = value)  _
						= false) Then
				Me.OnUserIDChanging(value)
				Me.SendPropertyChanging
				Me._UserID = value
				Me.SendPropertyChanged("UserID")
				Me.OnUserIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UserName", DbType:="NVarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property UserName() As String
		Get
			Return Me._UserName
		End Get
		Set
			If (String.Equals(Me._UserName, value) = false) Then
				Me.OnUserNameChanging(value)
				Me.SendPropertyChanging
				Me._UserName = value
				Me.SendPropertyChanged("UserName")
				Me.OnUserNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Password", DbType:="Binary(32)", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Password() As System.Data.Linq.Binary
		Get
			Return Me._Password
		End Get
		Set
			If (Object.Equals(Me._Password, value) = false) Then
				Me.OnPasswordChanging(value)
				Me.SendPropertyChanging
				Me._Password = value
				Me.SendPropertyChanged("Password")
				Me.OnPasswordChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FirstName", DbType:="NVarChar(50)")>  _
	Public Property FirstName() As String
		Get
			Return Me._FirstName
		End Get
		Set
			If (String.Equals(Me._FirstName, value) = false) Then
				Me.OnFirstNameChanging(value)
				Me.SendPropertyChanging
				Me._FirstName = value
				Me.SendPropertyChanged("FirstName")
				Me.OnFirstNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_LastName", DbType:="NVarChar(50)")>  _
	Public Property LastName() As String
		Get
			Return Me._LastName
		End Get
		Set
			If (String.Equals(Me._LastName, value) = false) Then
				Me.OnLastNameChanging(value)
				Me.SendPropertyChanging
				Me._LastName = value
				Me.SendPropertyChanged("LastName")
				Me.OnLastNameChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Disabled", DbType:="Bit NOT NULL")>  _
	Public Property Disabled() As Boolean
		Get
			Return Me._Disabled
		End Get
		Set
			If ((Me._Disabled = value)  _
						= false) Then
				Me.OnDisabledChanging(value)
				Me.SendPropertyChanging
				Me._Disabled = value
				Me.SendPropertyChanged("Disabled")
				Me.OnDisabledChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PersonalNo", DbType:="Int")>  _
	Public Property PersonalNo() As System.Nullable(Of Integer)
		Get
			Return Me._PersonalNo
		End Get
		Set
			If (Me._PersonalNo.Equals(value) = false) Then
				Me.OnPersonalNoChanging(value)
				Me.SendPropertyChanging
				Me._PersonalNo = value
				Me.SendPropertyChanged("PersonalNo")
				Me.OnPersonalNoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Descriptions", DbType:="NVarChar(MAX)")>  _
	Public Property Descriptions() As String
		Get
			Return Me._Descriptions
		End Get
		Set
			If (String.Equals(Me._Descriptions, value) = false) Then
				Me.OnDescriptionsChanging(value)
				Me.SendPropertyChanging
				Me._Descriptions = value
				Me.SendPropertyChanged("Descriptions")
				Me.OnDescriptionsChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ApplicationID", DbType:="Int")>  _
	Public Property ApplicationID() As System.Nullable(Of Integer)
		Get
			Return Me._ApplicationID
		End Get
		Set
			If (Me._ApplicationID.Equals(value) = false) Then
				If Me._tblApplication.HasLoadedOrAssignedValue Then
					Throw New System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException()
				End If
				Me.OnApplicationIDChanging(value)
				Me.SendPropertyChanging
				Me._ApplicationID = value
				Me.SendPropertyChanged("ApplicationID")
				Me.OnApplicationIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SystemDescriptions", DbType:="NVarChar(MAX)")>  _
	Public Property SystemDescriptions() As String
		Get
			Return Me._SystemDescriptions
		End Get
		Set
			If (String.Equals(Me._SystemDescriptions, value) = false) Then
				Me.OnSystemDescriptionsChanging(value)
				Me.SendPropertyChanging
				Me._SystemDescriptions = value
				Me.SendPropertyChanged("SystemDescriptions")
				Me.OnSystemDescriptionsChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Sex", DbType:="Bit")>  _
	Public Property Sex() As System.Nullable(Of Boolean)
		Get
			Return Me._Sex
		End Get
		Set
			If (Me._Sex.Equals(value) = false) Then
				Me.OnSexChanging(value)
				Me.SendPropertyChanging
				Me._Sex = value
				Me.SendPropertyChanged("Sex")
				Me.OnSexChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IsNurse", DbType:="Bit")>  _
	Public Property IsNurse() As System.Nullable(Of Boolean)
		Get
			Return Me._IsNurse
		End Get
		Set
			If (Me._IsNurse.Equals(value) = false) Then
				Me.OnIsNurseChanging(value)
				Me.SendPropertyChanging
				Me._IsNurse = value
				Me.SendPropertyChanged("IsNurse")
				Me.OnIsNurseChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_shshGroup", DbType:="NVarChar(50)")>  _
	Public Property shshGroup() As String
		Get
			Return Me._shshGroup
		End Get
		Set
			If (String.Equals(Me._shshGroup, value) = false) Then
				Me.OnshshGroupChanging(value)
				Me.SendPropertyChanging
				Me._shshGroup = value
				Me.SendPropertyChanged("shshGroup")
				Me.OnshshGroupChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RoleID", DbType:="Int")>  _
	Public Property RoleID() As System.Nullable(Of Integer)
		Get
			Return Me._RoleID
		End Get
		Set
			If (Me._RoleID.Equals(value) = false) Then
				Me.OnRoleIDChanging(value)
				Me.SendPropertyChanging
				Me._RoleID = value
				Me.SendPropertyChanged("RoleID")
				Me.OnRoleIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.AssociationAttribute(Name:="tblApplication_tblUser", Storage:="_tblApplication", ThisKey:="ApplicationID", OtherKey:="ApplicationID", IsForeignKey:=true)>  _
	Public Property tblApplication() As tblApplication
		Get
			Return Me._tblApplication.Entity
		End Get
		Set
			Dim previousValue As tblApplication = Me._tblApplication.Entity
			If ((Object.Equals(previousValue, value) = false)  _
						OrElse (Me._tblApplication.HasLoadedOrAssignedValue = false)) Then
				Me.SendPropertyChanging
				If ((previousValue Is Nothing)  _
							= false) Then
					Me._tblApplication.Entity = Nothing
					previousValue.tblUsers.Remove(Me)
				End If
				Me._tblApplication.Entity = value
				If ((value Is Nothing)  _
							= false) Then
					value.tblUsers.Add(Me)
					Me._ApplicationID = value.ApplicationID
				Else
					Me._ApplicationID = CType(Nothing, Nullable(Of Integer))
				End If
				Me.SendPropertyChanged("tblApplication")
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
