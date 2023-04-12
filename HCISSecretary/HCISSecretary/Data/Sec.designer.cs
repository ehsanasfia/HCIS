﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCISSecretary.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SecurityControl")]
	public partial class SecDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblUser(tblUser instance);
    partial void UpdatetblUser(tblUser instance);
    partial void DeletetblUser(tblUser instance);
    partial void InserttblApplication(tblApplication instance);
    partial void UpdatetblApplication(tblApplication instance);
    partial void DeletetblApplication(tblApplication instance);
    partial void InserttblApplicationDepartment(tblApplicationDepartment instance);
    partial void UpdatetblApplicationDepartment(tblApplicationDepartment instance);
    partial void DeletetblApplicationDepartment(tblApplicationDepartment instance);
    partial void InserttblUserAccessibleDepartment(tblUserAccessibleDepartment instance);
    partial void UpdatetblUserAccessibleDepartment(tblUserAccessibleDepartment instance);
    partial void DeletetblUserAccessibleDepartment(tblUserAccessibleDepartment instance);
    #endregion
		
		public SecDataContext() : 
				base(global::HCISSecretary.Properties.Settings.Default.SecurityControlConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SecDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SecDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblUser> tblUsers
		{
			get
			{
				return this.GetTable<tblUser>();
			}
		}
		
		public System.Data.Linq.Table<tblApplication> tblApplications
		{
			get
			{
				return this.GetTable<tblApplication>();
			}
		}
		
		public System.Data.Linq.Table<tblApplicationDepartment> tblApplicationDepartments
		{
			get
			{
				return this.GetTable<tblApplicationDepartment>();
			}
		}
		
		public System.Data.Linq.Table<tblUserAccessibleDepartment> tblUserAccessibleDepartments
		{
			get
			{
				return this.GetTable<tblUserAccessibleDepartment>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUsers")]
	public partial class tblUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _UserName;
		
		private System.Data.Linq.Binary _Password;
		
		private string _FirstName;
		
		private string _LastName;
		
		private bool _Disabled;
		
		private System.Nullable<int> _PersonalNo;
		
		private string _Descriptions;
		
		private System.Nullable<int> _ApplicationID;
		
		private string _SystemDescriptions;
		
		private System.Nullable<bool> _Sex;
		
		private System.Nullable<bool> _IsNurse;
		
		private string _shshGroup;
		
		private System.Nullable<int> _RoleID;
		
		private EntitySet<tblUserAccessibleDepartment> _tblUserAccessibleDepartments;
		
		private EntityRef<tblApplication> _tblApplication;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(System.Data.Linq.Binary value);
    partial void OnPasswordChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnDisabledChanging(bool value);
    partial void OnDisabledChanged();
    partial void OnPersonalNoChanging(System.Nullable<int> value);
    partial void OnPersonalNoChanged();
    partial void OnDescriptionsChanging(string value);
    partial void OnDescriptionsChanged();
    partial void OnApplicationIDChanging(System.Nullable<int> value);
    partial void OnApplicationIDChanged();
    partial void OnSystemDescriptionsChanging(string value);
    partial void OnSystemDescriptionsChanged();
    partial void OnSexChanging(System.Nullable<bool> value);
    partial void OnSexChanged();
    partial void OnIsNurseChanging(System.Nullable<bool> value);
    partial void OnIsNurseChanged();
    partial void OnshshGroupChanging(string value);
    partial void OnshshGroupChanged();
    partial void OnRoleIDChanging(System.Nullable<int> value);
    partial void OnRoleIDChanged();
    #endregion
		
		public tblUser()
		{
			this._tblUserAccessibleDepartments = new EntitySet<tblUserAccessibleDepartment>(new Action<tblUserAccessibleDepartment>(this.attach_tblUserAccessibleDepartments), new Action<tblUserAccessibleDepartment>(this.detach_tblUserAccessibleDepartments));
			this._tblApplication = default(EntityRef<tblApplication>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="Binary(32)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Disabled", DbType="Bit NOT NULL")]
		public bool Disabled
		{
			get
			{
				return this._Disabled;
			}
			set
			{
				if ((this._Disabled != value))
				{
					this.OnDisabledChanging(value);
					this.SendPropertyChanging();
					this._Disabled = value;
					this.SendPropertyChanged("Disabled");
					this.OnDisabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonalNo", DbType="Int")]
		public System.Nullable<int> PersonalNo
		{
			get
			{
				return this._PersonalNo;
			}
			set
			{
				if ((this._PersonalNo != value))
				{
					this.OnPersonalNoChanging(value);
					this.SendPropertyChanging();
					this._PersonalNo = value;
					this.SendPropertyChanged("PersonalNo");
					this.OnPersonalNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descriptions", DbType="NVarChar(MAX)")]
		public string Descriptions
		{
			get
			{
				return this._Descriptions;
			}
			set
			{
				if ((this._Descriptions != value))
				{
					this.OnDescriptionsChanging(value);
					this.SendPropertyChanging();
					this._Descriptions = value;
					this.SendPropertyChanged("Descriptions");
					this.OnDescriptionsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationID", DbType="Int")]
		public System.Nullable<int> ApplicationID
		{
			get
			{
				return this._ApplicationID;
			}
			set
			{
				if ((this._ApplicationID != value))
				{
					if (this._tblApplication.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIDChanging(value);
					this.SendPropertyChanging();
					this._ApplicationID = value;
					this.SendPropertyChanged("ApplicationID");
					this.OnApplicationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SystemDescriptions", DbType="NVarChar(MAX)")]
		public string SystemDescriptions
		{
			get
			{
				return this._SystemDescriptions;
			}
			set
			{
				if ((this._SystemDescriptions != value))
				{
					this.OnSystemDescriptionsChanging(value);
					this.SendPropertyChanging();
					this._SystemDescriptions = value;
					this.SendPropertyChanged("SystemDescriptions");
					this.OnSystemDescriptionsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Bit")]
		public System.Nullable<bool> Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsNurse", DbType="Bit")]
		public System.Nullable<bool> IsNurse
		{
			get
			{
				return this._IsNurse;
			}
			set
			{
				if ((this._IsNurse != value))
				{
					this.OnIsNurseChanging(value);
					this.SendPropertyChanging();
					this._IsNurse = value;
					this.SendPropertyChanged("IsNurse");
					this.OnIsNurseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shshGroup", DbType="NVarChar(50)")]
		public string shshGroup
		{
			get
			{
				return this._shshGroup;
			}
			set
			{
				if ((this._shshGroup != value))
				{
					this.OnshshGroupChanging(value);
					this.SendPropertyChanging();
					this._shshGroup = value;
					this.SendPropertyChanged("shshGroup");
					this.OnshshGroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int")]
		public System.Nullable<int> RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this.OnRoleIDChanging(value);
					this.SendPropertyChanging();
					this._RoleID = value;
					this.SendPropertyChanged("RoleID");
					this.OnRoleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblUser_tblUserAccessibleDepartment", Storage="_tblUserAccessibleDepartments", ThisKey="UserID", OtherKey="UserID")]
		public EntitySet<tblUserAccessibleDepartment> tblUserAccessibleDepartments
		{
			get
			{
				return this._tblUserAccessibleDepartments;
			}
			set
			{
				this._tblUserAccessibleDepartments.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblApplication_tblUser", Storage="_tblApplication", ThisKey="ApplicationID", OtherKey="ApplicationID", IsForeignKey=true)]
		public tblApplication tblApplication
		{
			get
			{
				return this._tblApplication.Entity;
			}
			set
			{
				tblApplication previousValue = this._tblApplication.Entity;
				if (((previousValue != value) 
							|| (this._tblApplication.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblApplication.Entity = null;
						previousValue.tblUsers.Remove(this);
					}
					this._tblApplication.Entity = value;
					if ((value != null))
					{
						value.tblUsers.Add(this);
						this._ApplicationID = value.ApplicationID;
					}
					else
					{
						this._ApplicationID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tblApplication");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblUserAccessibleDepartments(tblUserAccessibleDepartment entity)
		{
			this.SendPropertyChanging();
			entity.tblUser = this;
		}
		
		private void detach_tblUserAccessibleDepartments(tblUserAccessibleDepartment entity)
		{
			this.SendPropertyChanging();
			entity.tblUser = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblApplications")]
	public partial class tblApplication : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ApplicationID;
		
		private string _ApplicationName;
		
		private string _Description;
		
		private EntitySet<tblUser> _tblUsers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIDChanging(int value);
    partial void OnApplicationIDChanged();
    partial void OnApplicationNameChanging(string value);
    partial void OnApplicationNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public tblApplication()
		{
			this._tblUsers = new EntitySet<tblUser>(new Action<tblUser>(this.attach_tblUsers), new Action<tblUser>(this.detach_tblUsers));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ApplicationID
		{
			get
			{
				return this._ApplicationID;
			}
			set
			{
				if ((this._ApplicationID != value))
				{
					this.OnApplicationIDChanging(value);
					this.SendPropertyChanging();
					this._ApplicationID = value;
					this.SendPropertyChanged("ApplicationID");
					this.OnApplicationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ApplicationName
		{
			get
			{
				return this._ApplicationName;
			}
			set
			{
				if ((this._ApplicationName != value))
				{
					this.OnApplicationNameChanging(value);
					this.SendPropertyChanging();
					this._ApplicationName = value;
					this.SendPropertyChanged("ApplicationName");
					this.OnApplicationNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblApplication_tblUser", Storage="_tblUsers", ThisKey="ApplicationID", OtherKey="ApplicationID")]
		public EntitySet<tblUser> tblUsers
		{
			get
			{
				return this._tblUsers;
			}
			set
			{
				this._tblUsers.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblUsers(tblUser entity)
		{
			this.SendPropertyChanging();
			entity.tblApplication = this;
		}
		
		private void detach_tblUsers(tblUser entity)
		{
			this.SendPropertyChanging();
			entity.tblApplication = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblApplicationDepartments")]
	public partial class tblApplicationDepartment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _AppID;
		
		private int _DepID;
		
		private EntitySet<tblUserAccessibleDepartment> _tblUserAccessibleDepartments;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnAppIDChanging(int value);
    partial void OnAppIDChanged();
    partial void OnDepIDChanging(int value);
    partial void OnDepIDChanged();
    #endregion
		
		public tblApplicationDepartment()
		{
			this._tblUserAccessibleDepartments = new EntitySet<tblUserAccessibleDepartment>(new Action<tblUserAccessibleDepartment>(this.attach_tblUserAccessibleDepartments), new Action<tblUserAccessibleDepartment>(this.detach_tblUserAccessibleDepartments));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AppID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				if ((this._AppID != value))
				{
					this.OnAppIDChanging(value);
					this.SendPropertyChanging();
					this._AppID = value;
					this.SendPropertyChanged("AppID");
					this.OnAppIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int DepID
		{
			get
			{
				return this._DepID;
			}
			set
			{
				if ((this._DepID != value))
				{
					this.OnDepIDChanging(value);
					this.SendPropertyChanging();
					this._DepID = value;
					this.SendPropertyChanged("DepID");
					this.OnDepIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblApplicationDepartment_tblUserAccessibleDepartment", Storage="_tblUserAccessibleDepartments", ThisKey="ID", OtherKey="AppAccessibleID")]
		public EntitySet<tblUserAccessibleDepartment> tblUserAccessibleDepartments
		{
			get
			{
				return this._tblUserAccessibleDepartments;
			}
			set
			{
				this._tblUserAccessibleDepartments.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblUserAccessibleDepartments(tblUserAccessibleDepartment entity)
		{
			this.SendPropertyChanging();
			entity.tblApplicationDepartment = this;
		}
		
		private void detach_tblUserAccessibleDepartments(tblUserAccessibleDepartment entity)
		{
			this.SendPropertyChanging();
			entity.tblApplicationDepartment = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUserAccessibleDepartments")]
	public partial class tblUserAccessibleDepartment : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private int _AppAccessibleID;
		
		private EntityRef<tblApplicationDepartment> _tblApplicationDepartment;
		
		private EntityRef<tblUser> _tblUser;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnAppAccessibleIDChanging(int value);
    partial void OnAppAccessibleIDChanged();
    #endregion
		
		public tblUserAccessibleDepartment()
		{
			this._tblApplicationDepartment = default(EntityRef<tblApplicationDepartment>);
			this._tblUser = default(EntityRef<tblUser>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._tblUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AppAccessibleID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AppAccessibleID
		{
			get
			{
				return this._AppAccessibleID;
			}
			set
			{
				if ((this._AppAccessibleID != value))
				{
					if (this._tblApplicationDepartment.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAppAccessibleIDChanging(value);
					this.SendPropertyChanging();
					this._AppAccessibleID = value;
					this.SendPropertyChanged("AppAccessibleID");
					this.OnAppAccessibleIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblApplicationDepartment_tblUserAccessibleDepartment", Storage="_tblApplicationDepartment", ThisKey="AppAccessibleID", OtherKey="ID", IsForeignKey=true)]
		public tblApplicationDepartment tblApplicationDepartment
		{
			get
			{
				return this._tblApplicationDepartment.Entity;
			}
			set
			{
				tblApplicationDepartment previousValue = this._tblApplicationDepartment.Entity;
				if (((previousValue != value) 
							|| (this._tblApplicationDepartment.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblApplicationDepartment.Entity = null;
						previousValue.tblUserAccessibleDepartments.Remove(this);
					}
					this._tblApplicationDepartment.Entity = value;
					if ((value != null))
					{
						value.tblUserAccessibleDepartments.Add(this);
						this._AppAccessibleID = value.ID;
					}
					else
					{
						this._AppAccessibleID = default(int);
					}
					this.SendPropertyChanged("tblApplicationDepartment");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblUser_tblUserAccessibleDepartment", Storage="_tblUser", ThisKey="UserID", OtherKey="UserID", IsForeignKey=true)]
		public tblUser tblUser
		{
			get
			{
				return this._tblUser.Entity;
			}
			set
			{
				tblUser previousValue = this._tblUser.Entity;
				if (((previousValue != value) 
							|| (this._tblUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblUser.Entity = null;
						previousValue.tblUserAccessibleDepartments.Remove(this);
					}
					this._tblUser.Entity = value;
					if ((value != null))
					{
						value.tblUserAccessibleDepartments.Add(this);
						this._UserID = value.UserID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("tblUser");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
