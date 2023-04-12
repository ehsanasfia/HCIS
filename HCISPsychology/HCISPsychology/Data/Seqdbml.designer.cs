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

namespace HCISPsychology.Data
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
	public partial class SeqdbmlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblUser(tblUser instance);
    partial void UpdatetblUser(tblUser instance);
    partial void DeletetblUser(tblUser instance);
    #endregion
		
		public SeqdbmlDataContext() : 
				base(global::HCISPsychology.Properties.Settings.Default.SecurityControlConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SeqdbmlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SeqdbmlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SeqdbmlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SeqdbmlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
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
