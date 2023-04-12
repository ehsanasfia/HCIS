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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Jamiat")]
	public partial class JamiatDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTbl_ValidCenterZone(Tbl_ValidCenterZone instance);
    partial void UpdateTbl_ValidCenterZone(Tbl_ValidCenterZone instance);
    partial void DeleteTbl_ValidCenterZone(Tbl_ValidCenterZone instance);
    partial void InsertTbl_ValidCenter(Tbl_ValidCenter instance);
    partial void UpdateTbl_ValidCenter(Tbl_ValidCenter instance);
    partial void DeleteTbl_ValidCenter(Tbl_ValidCenter instance);
    #endregion
		
		public JamiatDataContext() : 
				base(global::HealthAndFamilyReportHCIS.Properties.Settings.Default.JamiatConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public JamiatDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JamiatDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JamiatDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JamiatDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Tbl_ValidCenterZone> Tbl_ValidCenterZones
		{
			get
			{
				return this.GetTable<Tbl_ValidCenterZone>();
			}
		}
		
		public System.Data.Linq.Table<Tbl_ValidCenter> Tbl_ValidCenters
		{
			get
			{
				return this.GetTable<Tbl_ValidCenter>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tbl_ValidCenterZone")]
	public partial class Tbl_ValidCenterZone : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDValidCenterZone;
		
		private string _Name;
		
		private bool _Deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDValidCenterZoneChanging(int value);
    partial void OnIDValidCenterZoneChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDeletedChanging(bool value);
    partial void OnDeletedChanged();
    #endregion
		
		public Tbl_ValidCenterZone()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterZone", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDValidCenterZone
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Deleted", DbType="Bit NOT NULL")]
		public bool Deleted
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tbl_ValidCenter")]
	public partial class Tbl_ValidCenter : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IDValidCenter;
		
		private int _IDValidCenterZone;
		
		private byte _IDValidCenterType;
		
		private string _Name;
		
		private byte _Deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDValidCenterChanging(int value);
    partial void OnIDValidCenterChanged();
    partial void OnIDValidCenterZoneChanging(int value);
    partial void OnIDValidCenterZoneChanged();
    partial void OnIDValidCenterTypeChanging(byte value);
    partial void OnIDValidCenterTypeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDeletedChanging(byte value);
    partial void OnDeletedChanged();
    #endregion
		
		public Tbl_ValidCenter()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenter", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDValidCenter
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterZone", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IDValidCenterZone
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDValidCenterType", DbType="TinyInt NOT NULL", IsPrimaryKey=true)]
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
