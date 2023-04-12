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

namespace HealthAndFamilyReportHCIS.Data
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
    partial void InsertTbl_ValidCenterIMPHO(Tbl_ValidCenterIMPHO instance);
    partial void UpdateTbl_ValidCenterIMPHO(Tbl_ValidCenterIMPHO instance);
    partial void DeleteTbl_ValidCenterIMPHO(Tbl_ValidCenterIMPHO instance);
    partial void InsertTbl_ValidCenterZoneIMPHO(Tbl_ValidCenterZoneIMPHO instance);
    partial void UpdateTbl_ValidCenterZoneIMPHO(Tbl_ValidCenterZoneIMPHO instance);
    partial void DeleteTbl_ValidCenterZoneIMPHO(Tbl_ValidCenterZoneIMPHO instance);
    #endregion
		
		public IMPHODataContext() : 
				base(global::HealthAndFamilyReportHCIS.Properties.Settings.Default.IMPHOConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Tbl_ValidCenterIMPHO> Tbl_ValidCenterIMPHOs
		{
			get
			{
				return this.GetTable<Tbl_ValidCenterIMPHO>();
			}
		}
		
		public System.Data.Linq.Table<Tbl_ValidCenterZoneIMPHO> Tbl_ValidCenterZoneIMPHOs
		{
			get
			{
				return this.GetTable<Tbl_ValidCenterZoneIMPHO>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tbl_ValidCenter")]
	public partial class Tbl_ValidCenterIMPHO : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _IDValidCenter;
		
		private byte _IDValidCenterZone;
		
		private byte _IDValidCenterType;
		
		private byte _Level;
		
		private string _Name;
		
		private string _CreationDate;
		
		private string _CreationTime;
		
		private string _CreationOperator;
		
		private string _LastModificationDate;
		
		private string _LastModificationTime;
		
		private string _LastModificationOperator;
		
		private byte _Deleted;
		
		private System.Guid _rowguid;
		
		private System.Nullable<int> _NewIDValidCenter;
		
		private System.Nullable<byte> _NewIDValidCenterZone;
		
		private EntityRef<Tbl_ValidCenterZoneIMPHO> _Tbl_ValidCenterZoneIMPHO;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDValidCenterChanging(short value);
    partial void OnIDValidCenterChanged();
    partial void OnIDValidCenterZoneChanging(byte value);
    partial void OnIDValidCenterZoneChanged();
    partial void OnIDValidCenterTypeChanging(byte value);
    partial void OnIDValidCenterTypeChanged();
    partial void OnLevelChanging(byte value);
    partial void OnLevelChanged();
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
    partial void OnNewIDValidCenterChanging(System.Nullable<int> value);
    partial void OnNewIDValidCenterChanged();
    partial void OnNewIDValidCenterZoneChanging(System.Nullable<byte> value);
    partial void OnNewIDValidCenterZoneChanged();
    #endregion
		
		public Tbl_ValidCenterIMPHO()
		{
			this._Tbl_ValidCenterZoneIMPHO = default(EntityRef<Tbl_ValidCenterZoneIMPHO>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenter", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short IDValidCenter
		{
			get
			{
				return this._IDValidCenter;
			}
			set
			{
				if ((this._IDValidCenter != value))
				{
					this.OnIDValidCenterChanging(value);
					this.SendPropertyChanging();
					this._IDValidCenter = value;
					this.SendPropertyChanged("IDValidCenter");
					this.OnIDValidCenterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterZone", DbType="TinyInt NOT NULL")]
		public byte IDValidCenterZone
		{
			get
			{
				return this._IDValidCenterZone;
			}
			set
			{
				if ((this._IDValidCenterZone != value))
				{
					if (this._Tbl_ValidCenterZoneIMPHO.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDValidCenterZoneChanging(value);
					this.SendPropertyChanging();
					this._IDValidCenterZone = value;
					this.SendPropertyChanged("IDValidCenterZone");
					this.OnIDValidCenterZoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterType", DbType="TinyInt NOT NULL")]
		public byte IDValidCenterType
		{
			get
			{
				return this._IDValidCenterType;
			}
			set
			{
				if ((this._IDValidCenterType != value))
				{
					this.OnIDValidCenterTypeChanging(value);
					this.SendPropertyChanging();
					this._IDValidCenterType = value;
					this.SendPropertyChanged("IDValidCenterType");
					this.OnIDValidCenterTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="TinyInt NOT NULL")]
		public byte Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._Level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(70) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewIDValidCenter", DbType="Int")]
		public System.Nullable<int> NewIDValidCenter
		{
			get
			{
				return this._NewIDValidCenter;
			}
			set
			{
				if ((this._NewIDValidCenter != value))
				{
					this.OnNewIDValidCenterChanging(value);
					this.SendPropertyChanging();
					this._NewIDValidCenter = value;
					this.SendPropertyChanged("NewIDValidCenter");
					this.OnNewIDValidCenterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewIDValidCenterZone", DbType="TinyInt")]
		public System.Nullable<byte> NewIDValidCenterZone
		{
			get
			{
				return this._NewIDValidCenterZone;
			}
			set
			{
				if ((this._NewIDValidCenterZone != value))
				{
					this.OnNewIDValidCenterZoneChanging(value);
					this.SendPropertyChanging();
					this._NewIDValidCenterZone = value;
					this.SendPropertyChanged("NewIDValidCenterZone");
					this.OnNewIDValidCenterZoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tbl_ValidCenterZone_Tbl_ValidCenter", Storage="_Tbl_ValidCenterZoneIMPHO", ThisKey="IDValidCenterZone", OtherKey="IDValidCenterZone", IsForeignKey=true)]
		public Tbl_ValidCenterZoneIMPHO Tbl_ValidCenterZoneIMPHO
		{
			get
			{
				return this._Tbl_ValidCenterZoneIMPHO.Entity;
			}
			set
			{
				Tbl_ValidCenterZoneIMPHO previousValue = this._Tbl_ValidCenterZoneIMPHO.Entity;
				if (((previousValue != value) 
							|| (this._Tbl_ValidCenterZoneIMPHO.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tbl_ValidCenterZoneIMPHO.Entity = null;
						previousValue.Tbl_ValidCenterIMPHOs.Remove(this);
					}
					this._Tbl_ValidCenterZoneIMPHO.Entity = value;
					if ((value != null))
					{
						value.Tbl_ValidCenterIMPHOs.Add(this);
						this._IDValidCenterZone = value.IDValidCenterZone;
					}
					else
					{
						this._IDValidCenterZone = default(byte);
					}
					this.SendPropertyChanged("Tbl_ValidCenterZoneIMPHO");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tbl_ValidCenterZone")]
	public partial class Tbl_ValidCenterZoneIMPHO : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private byte _IDValidCenterZone;
		
		private string _Name;
		
		private int _Access;
		
		private string _CreationDate;
		
		private string _CreationTime;
		
		private string _CreationOperator;
		
		private string _LastModificationDate;
		
		private string _LastModificationTime;
		
		private string _LastModificationOperator;
		
		private byte _Deleted;
		
		private System.Guid _rowguid;
		
		private System.Nullable<byte> _NewIDValidCenterZone;
		
		private EntitySet<Tbl_ValidCenterIMPHO> _Tbl_ValidCenterIMPHOs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDValidCenterZoneChanging(byte value);
    partial void OnIDValidCenterZoneChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAccessChanging(int value);
    partial void OnAccessChanged();
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
    partial void OnNewIDValidCenterZoneChanging(System.Nullable<byte> value);
    partial void OnNewIDValidCenterZoneChanged();
    #endregion
		
		public Tbl_ValidCenterZoneIMPHO()
		{
			this._Tbl_ValidCenterIMPHOs = new EntitySet<Tbl_ValidCenterIMPHO>(new Action<Tbl_ValidCenterIMPHO>(this.attach_Tbl_ValidCenterIMPHOs), new Action<Tbl_ValidCenterIMPHO>(this.detach_Tbl_ValidCenterIMPHOs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterZone", DbType="TinyInt NOT NULL", IsPrimaryKey=true)]
		public byte IDValidCenterZone
		{
			get
			{
				return this._IDValidCenterZone;
			}
			set
			{
				if ((this._IDValidCenterZone != value))
				{
					this.OnIDValidCenterZoneChanging(value);
					this.SendPropertyChanging();
					this._IDValidCenterZone = value;
					this.SendPropertyChanged("IDValidCenterZone");
					this.OnIDValidCenterZoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(70) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Access", DbType="Int NOT NULL")]
		public int Access
		{
			get
			{
				return this._Access;
			}
			set
			{
				if ((this._Access != value))
				{
					this.OnAccessChanging(value);
					this.SendPropertyChanging();
					this._Access = value;
					this.SendPropertyChanged("Access");
					this.OnAccessChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewIDValidCenterZone", DbType="TinyInt")]
		public System.Nullable<byte> NewIDValidCenterZone
		{
			get
			{
				return this._NewIDValidCenterZone;
			}
			set
			{
				if ((this._NewIDValidCenterZone != value))
				{
					this.OnNewIDValidCenterZoneChanging(value);
					this.SendPropertyChanging();
					this._NewIDValidCenterZone = value;
					this.SendPropertyChanged("NewIDValidCenterZone");
					this.OnNewIDValidCenterZoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tbl_ValidCenterZone_Tbl_ValidCenter", Storage="_Tbl_ValidCenterIMPHOs", ThisKey="IDValidCenterZone", OtherKey="IDValidCenterZone")]
		public EntitySet<Tbl_ValidCenterIMPHO> Tbl_ValidCenterIMPHOs
		{
			get
			{
				return this._Tbl_ValidCenterIMPHOs;
			}
			set
			{
				this._Tbl_ValidCenterIMPHOs.Assign(value);
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
		
		private void attach_Tbl_ValidCenterIMPHOs(Tbl_ValidCenterIMPHO entity)
		{
			this.SendPropertyChanging();
			entity.Tbl_ValidCenterZoneIMPHO = this;
		}
		
		private void detach_Tbl_ValidCenterIMPHOs(Tbl_ValidCenterIMPHO entity)
		{
			this.SendPropertyChanging();
			entity.Tbl_ValidCenterZoneIMPHO = null;
		}
	}
}
#pragma warning restore 1591