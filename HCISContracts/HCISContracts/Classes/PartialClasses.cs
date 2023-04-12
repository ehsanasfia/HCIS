using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISContracts.Data;

namespace HCISContracts.Data
{
    public partial class Person
    {
        private string _FullName;
        public string FullName
        {
            get
            {
                return this._FullName=this.FirstName +" "+ this.LastName;
            }
            set
            {
                if ((this._FullName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.SendPropertyChanging();
                    this._FullName = value;
                    this.SendPropertyChanged("FullName");
                    this.OnFirstNameChanged();
                }
            }
        }
    }
}
