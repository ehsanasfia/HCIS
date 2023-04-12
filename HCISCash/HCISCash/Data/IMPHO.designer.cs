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

namespace HCISCash.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="IMPHO")]
	public partial class IMPHODataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTbl_Company(Tbl_Company instance);
    partial void UpdateTbl_Company(Tbl_Company instance);
    partial void DeleteTbl_Company(Tbl_Company instance);
    #endregion
		
		public IMPHODataContext() : 
				base(global::HCISCash.Properties.Settings.Default.IMPHOConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public IMPHODataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IMPHODataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IMPHODataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public IMPHODataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Tbl_Company> Tbl_Companies
		{
			get
			{
				return this.GetTable<Tbl_Company>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tbl_Company")]
	public partial class Tbl_Company : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _IDCompany;
		
		private byte _IDManagement;
		
		private string _Name;
		
		private string _CreationDate;
		
		private string _CreationTime;
		
		private string _CreationOperator;
		
		private string _LastModificationDate;
		
		private string _LastModificationTime;
		
		private string _LastModificationOperator;
		
		private byte _Deleted;
		
		private System.Guid _rowguid;
		
		private System.Nullable<int> _IDCo;
		
		private System.Nullable<int> _IDMg;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDCompanyChanging(short value);
    partial void OnIDCompanyChanged();
    partial void OnIDManagementChanging(byte value);
    partial void OnIDManagementChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnCreationDateChanging(string value);
    partial void OnCreationDateChanged();
    partial void OnCreationTimeChanging(string value);
    partial void OnCreationTimeChanged();
    partial void OnCreationOperatorChanging(string value);
    partial void OnCreationOperatorChanged();
    partial void OnLastModificationDateChanging(string value);
    partial void OnLastModificationDateChanged();
    partial void OnLastModificationTimeChanging(string value);
    partial void OnLastModificationTimeChanged();
    partial void OnLastModificationOperatorChanging(string value);
    partial void OnLastModificationOperatorChanged();
    partial void OnDeletedChanging(byte value);
    partial void OnDeletedChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnIDCoChanging(System.Nullable<int> value);
    partial void OnIDCoChanged();
    partial void OnIDMgChanging(System.Nullable<int> value);
    partial void OnIDMgChanged();
    #endregion
		
		public Tbl_Company()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDCompany", DbType="SmallInt NOT NULL", IsPrimaryKey=true)]
		public short IDCompany
		{
			get
			{
				return this._IDCompany;
			}
			set
			{
				if ((this._IDCompany != value))
				{
					this.OnIDCompanyChanging(value);
					this.SendPropertyChanging();
					this._IDCompany = value;
					this.SendPropertyChanged("IDCompany");
					this.OnIDCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDManagement", DbType="TinyInt NOT NULL")]
		public byte IDManagement
		{
			get
			{
				return this._IDManagement;
			}
			set
			{
				if ((this._IDManagement != value))
				{
					this.OnIDManagementChanging(value);
					this.SendPropertyChanging();
					this._IDManagement = value;
					this.SendPropertyChanged("IDManagement");
					this.OnIDManagementChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(80) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationDate", DbType="NChar(10)")]
		public string CreationDate
		{
			get
			{
				return this._CreationDate;
			}
			set
			{
				if ((this._CreationDate != value))
				{
					this.OnCreationDateChanging(value);
					this.SendPropertyChanging();
					this._CreationDate = value;
					this.SendPropertyChanged("CreationDate");
					this.OnCreationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTime", DbType="NChar(5)")]
		public string CreationTime
		{
			get
			{
				return this._CreationTime;
			}
			set
			{
				if ((this._CreationTime != value))
				{
					this.OnCreationTimeChanging(value);
					this.SendPropertyChanging();
					this._CreationTime = value;
					this.SendPropertyChanged("CreationTime");
					this.OnCreationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationOperator", DbType="NVarChar(40)")]
		public string CreationOperator
		{
			get
			{
				return this._CreationOperator;
			}
			set
			{
				if ((this._CreationOperator != value))
				{
					this.OnCreationOperatorChanging(value);
					this.SendPropertyChanging();
					this._CreationOperator = value;
					this.SendPropertyChanged("CreationOperator");
					this.OnCreationOperatorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModificationDate", DbType="NChar(10)")]
		public string LastModificationDate
		{
			get
			{
				return this._LastModificationDate;
			}
			set
			{
				if ((this._LastModificationDate != value))
				{
					this.OnLastModificationDateChanging(value);
					this.SendPropertyChanging();
					this._LastModificationDate = value;
					this.SendPropertyChanged("LastModificationDate");
					this.OnLastModificationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModificationTime", DbType="NChar(5)")]
		public string LastModificationTime
		{
			get
			{
				return this._LastModificationTime;
			}
			set
			{
				if ((this._LastModificationTime != value))
				{
					this.OnLastModificationTimeChanging(value);
					this.SendPropertyChanging();
					this._LastModificationTime = value;
					this.SendPropertyChanged("LastModificationTime");
					this.OnLastModificationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModificationOperator", DbType="NVarChar(40)")]
		public string LastModificationOperator
		{
			get
			{
				return this._LastModificationOperator;
			}
			set
			{
				if ((this._LastModificationOperator != value))
				{
					this.OnLastModificationOperatorChanging(value);
					this.SendPropertyChanging();
					this._LastModificationOperator = value;
					this.SendPropertyChanged("LastModificationOperator");
					this.OnLastModificationOperatorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Deleted", DbType="TinyInt NOT NULL")]
		public byte Deleted
		{
			get
			{
				return this._Deleted;
			}
			set
			{
				if ((this._Deleted != value))
				{
					this.OnDeletedChanging(value);
					this.SendPropertyChanging();
					this._Deleted = value;
					this.SendPropertyChanged("Deleted");
					this.OnDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDCo", DbType="Int")]
		public System.Nullable<int> IDCo
		{
			get
			{
				return this._IDCo;
			}
			set
			{
				if ((this._IDCo != value))
				{
					this.OnIDCoChanging(value);
					this.SendPropertyChanging();
					this._IDCo = value;
					this.SendPropertyChanged("IDCo");
					this.OnIDCoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDMg", DbType="Int")]
		public System.Nullable<int> IDMg
		{
			get
			{
				return this._IDMg;
			}
			set
			{
				if ((this._IDMg != value))
				{
					this.OnIDMgChanging(value);
					this.SendPropertyChanging();
					this._IDMg = value;
					this.SendPropertyChanged("IDMg");
					this.OnIDMgChanged();
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
