using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISDentist.Classes;

namespace HCISDentist.Data
{
    public partial class Service
    {
        private string _Comment;
        private float _Amount;
        private DrugFrequencyUsage _HIX;
        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                if ((this._Comment != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Comment = value;
                    this.SendPropertyChanged("Comment");
                    this.OnNameChanged();
                }
            }
        }

        public DrugFrequencyUsage HIX
        {
            get
            {
                return this._HIX;
            }
            set
            {
                if ((this._HIX != value))
                {
                    this.SendPropertyChanging();
                    this._HIX = value;
                    this.SendPropertyChanged("HIX");

                }
            }
        }

        public float Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                if ((this._Amount != value))
                {
                    this.OnNameChanging(value.ToString());
                    this.SendPropertyChanging();
                    this._Amount = value;
                    this.SendPropertyChanged("Amount");
                    this.OnNameChanged();
                }
            }
        }
    }
    public partial class Person
    {
        private int _age;

        public int Age
        {
            get
            {
                if (this._BirthDate != null)
                {
                    if (_BirthDate == "" || _BirthDate == null)
                        return 0;
                    var now = MainModule.GetPersianFirstDateOfYear(DateTime.Now);
                    try
                    {
                        this._age = int.Parse(now.Substring(0, 4)) - int.Parse(BirthDate.Substring(0, 4));

                    }
                    catch (Exception)
                    {
                        this._age = 0;
                    }

                }
                return this._age;
            }

        }


        private string _FullName;
        public string FullName
        {
            get
            {
                return this._FullName = this.FirstName + " " + this.LastName;
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

