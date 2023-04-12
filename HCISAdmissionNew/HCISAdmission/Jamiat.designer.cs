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

namespace HCISAdmission
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
    partial void InsertMemberPhoto(MemberPhoto instance);
    partial void UpdateMemberPhoto(MemberPhoto instance);
    partial void DeleteMemberPhoto(MemberPhoto instance);
    #endregion
		
		public JamiatDataContext() : 
				base(global::HCISAdmission.Properties.Settings.Default.JamiatConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<MemberPhoto> MemberPhotos
		{
			get
			{
				return this.GetTable<MemberPhoto>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.MemberPhoto")]
	public partial class MemberPhoto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IDPerson;
		
		private System.Data.Linq.Binary _Photo;
		
		private System.Guid _IDOpr1;
		
		private System.Guid _IDOpr2;
		
		private int _OprDate1;
		
		private int _OprDate2;
		
		private string _OprTime1;
		
		private string _OprTime2;
		
		private int _IDPersonOld;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDPersonChanging(System.Guid value);
    partial void OnIDPersonChanged();
    partial void OnPhotoChanging(System.Data.Linq.Binary value);
    partial void OnPhotoChanged();
    partial void OnIDOpr1Changing(System.Guid value);
    partial void OnIDOpr1Changed();
    partial void OnIDOpr2Changing(System.Guid value);
    partial void OnIDOpr2Changed();
    partial void OnOprDate1Changing(int value);
    partial void OnOprDate1Changed();
    partial void OnOprDate2Changing(int value);
    partial void OnOprDate2Changed();
    partial void OnOprTime1Changing(string value);
    partial void OnOprTime1Changed();
    partial void OnOprTime2Changing(string value);
    partial void OnOprTime2Changed();
    partial void OnIDPersonOldChanging(int value);
    partial void OnIDPersonOldChanged();
    #endregion
		
		public MemberPhoto()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPerson", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IDPerson
		{
			get
			{
				return this._IDPerson;
			}
			set
			{
				if ((this._IDPerson != value))
				{
					this.OnIDPersonChanging(value);
					this.SendPropertyChanging();
					this._IDPerson = value;
					this.SendPropertyChanged("IDPerson");
					this.OnIDPersonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Photo", DbType="Image NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Photo
		{
			get
			{
				return this._Photo;
			}
			set
			{
				if ((this._Photo != value))
				{
					this.OnPhotoChanging(value);
					this.SendPropertyChanging();
					this._Photo = value;
					this.SendPropertyChanged("Photo");
					this.OnPhotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDOpr1", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IDOpr1
		{
			get
			{
				return this._IDOpr1;
			}
			set
			{
				if ((this._IDOpr1 != value))
				{
					this.OnIDOpr1Changing(value);
					this.SendPropertyChanging();
					this._IDOpr1 = value;
					this.SendPropertyChanged("IDOpr1");
					this.OnIDOpr1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDOpr2", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IDOpr2
		{
			get
			{
				return this._IDOpr2;
			}
			set
			{
				if ((this._IDOpr2 != value))
				{
					this.OnIDOpr2Changing(value);
					this.SendPropertyChanging();
					this._IDOpr2 = value;
					this.SendPropertyChanged("IDOpr2");
					this.OnIDOpr2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OprDate1", DbType="Int NOT NULL")]
		public int OprDate1
		{
			get
			{
				return this._OprDate1;
			}
			set
			{
				if ((this._OprDate1 != value))
				{
					this.OnOprDate1Changing(value);
					this.SendPropertyChanging();
					this._OprDate1 = value;
					this.SendPropertyChanged("OprDate1");
					this.OnOprDate1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OprDate2", DbType="Int NOT NULL")]
		public int OprDate2
		{
			get
			{
				return this._OprDate2;
			}
			set
			{
				if ((this._OprDate2 != value))
				{
					this.OnOprDate2Changing(value);
					this.SendPropertyChanging();
					this._OprDate2 = value;
					this.SendPropertyChanged("OprDate2");
					this.OnOprDate2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OprTime1", DbType="NVarChar(12) NOT NULL", CanBeNull=false)]
		public string OprTime1
		{
			get
			{
				return this._OprTime1;
			}
			set
			{
				if ((this._OprTime1 != value))
				{
					this.OnOprTime1Changing(value);
					this.SendPropertyChanging();
					this._OprTime1 = value;
					this.SendPropertyChanged("OprTime1");
					this.OnOprTime1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OprTime2", DbType="NVarChar(12) NOT NULL", CanBeNull=false)]
		public string OprTime2
		{
			get
			{
				return this._OprTime2;
			}
			set
			{
				if ((this._OprTime2 != value))
				{
					this.OnOprTime2Changing(value);
					this.SendPropertyChanging();
					this._OprTime2 = value;
					this.SendPropertyChanged("OprTime2");
					this.OnOprTime2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPersonOld", DbType="Int NOT NULL")]
		public int IDPersonOld
		{
			get
			{
				return this._IDPersonOld;
			}
			set
			{
				if ((this._IDPersonOld != value))
				{
					this.OnIDPersonOldChanging(value);
					this.SendPropertyChanging();
					this._IDPersonOld = value;
					this.SendPropertyChanged("IDPersonOld");
					this.OnIDPersonOldChanged();
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
