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

namespace HCISLab.DataHos
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Hospital")]
	public partial class HCISHosClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertService(Service instance);
    partial void UpdateService(Service instance);
    partial void DeleteService(Service instance);
    #endregion
		
		public HCISHosClassDataContext() : 
				base(global::HCISLab.Properties.Settings.Default.HospitalConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HCISHosClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HCISHosClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HCISHosClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HCISHosClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Service> Services
		{
			get
			{
				return this.GetTable<Service>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Service")]
	public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Uni;
		
		private System.Nullable<int> _Parent;
		
		private string _Service1;
		
		private System.Nullable<int> _Price;
		
		private string _LastModificationDate;
		
		private System.Nullable<bool> _Hide;
		
		private System.Nullable<int> _NationalID;
		
		private string _Attribute;
		
		private string _FullName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUniChanging(int value);
    partial void OnUniChanged();
    partial void OnParentChanging(System.Nullable<int> value);
    partial void OnParentChanged();
    partial void OnService1Changing(string value);
    partial void OnService1Changed();
    partial void OnPriceChanging(System.Nullable<int> value);
    partial void OnPriceChanged();
    partial void OnLastModificationDateChanging(string value);
    partial void OnLastModificationDateChanged();
    partial void OnHideChanging(System.Nullable<bool> value);
    partial void OnHideChanged();
    partial void OnNationalIDChanging(System.Nullable<int> value);
    partial void OnNationalIDChanged();
    partial void OnAttributeChanging(string value);
    partial void OnAttributeChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    #endregion
		
		public Service()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Uni", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Uni
		{
			get
			{
				return this._Uni;
			}
			set
			{
				if ((this._Uni != value))
				{
					this.OnUniChanging(value);
					this.SendPropertyChanging();
					this._Uni = value;
					this.SendPropertyChanged("Uni");
					this.OnUniChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Parent", DbType="Int")]
		public System.Nullable<int> Parent
		{
			get
			{
				return this._Parent;
			}
			set
			{
				if ((this._Parent != value))
				{
					this.OnParentChanging(value);
					this.SendPropertyChanging();
					this._Parent = value;
					this.SendPropertyChanged("Parent");
					this.OnParentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Service", Storage="_Service1", DbType="NVarChar(200)")]
		public string Service1
		{
			get
			{
				return this._Service1;
			}
			set
			{
				if ((this._Service1 != value))
				{
					this.OnService1Changing(value);
					this.SendPropertyChanging();
					this._Service1 = value;
					this.SendPropertyChanged("Service1");
					this.OnService1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int")]
		public System.Nullable<int> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModificationDate", DbType="Char(10)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hide", DbType="Bit")]
		public System.Nullable<bool> Hide
		{
			get
			{
				return this._Hide;
			}
			set
			{
				if ((this._Hide != value))
				{
					this.OnHideChanging(value);
					this.SendPropertyChanging();
					this._Hide = value;
					this.SendPropertyChanged("Hide");
					this.OnHideChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NationalID", DbType="Int")]
		public System.Nullable<int> NationalID
		{
			get
			{
				return this._NationalID;
			}
			set
			{
				if ((this._NationalID != value))
				{
					this.OnNationalIDChanging(value);
					this.SendPropertyChanging();
					this._NationalID = value;
					this.SendPropertyChanged("NationalID");
					this.OnNationalIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Attribute", DbType="NVarChar(50)")]
		public string Attribute
		{
			get
			{
				return this._Attribute;
			}
			set
			{
				if ((this._Attribute != value))
				{
					this.OnAttributeChanging(value);
					this.SendPropertyChanging();
					this._Attribute = value;
					this.SendPropertyChanged("Attribute");
					this.OnAttributeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(MAX)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
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
