using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISDefinitions.Data
{
    public partial class Person
    {
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
    public partial class Agenda
    {
        private string _Day;
        public string Day
        {
            get
            {
                return this._Day = MainModule.GetPersianDayOfWeek(MainModule.GetDateFromPersianString(this.Date).DayOfWeek);
            }
            set
            {
                if ((this._Day != value))
                {
                    this.SendPropertyChanging();
                    this._Day = value;
                    this.SendPropertyChanged("Day");
                }
            }
        }

        private string _RemainingDaysOrInfinite;

        public string RemainingDaysOrInfinite
        {
            get
            {

                if (Capacity == 0)
                {
                    _RemainingDaysOrInfinite = "بدون محدودیت";
                }
                else if (Capacity == null)
                {
                    _RemainingDaysOrInfinite = "";
                }
                else
                {
                    _RemainingDaysOrInfinite = (Capacity - GivenServiceMs.Count(x => x.VisitType != 19 && !x.Cancelled)).ToString();
                }

                return _RemainingDaysOrInfinite;
            }
            set { _RemainingDaysOrInfinite = value; }
        }


        private string _RemainingInaccessible;

        public string RemainingInaccessible
        {
            get
            {
                if (InaccessibleCapacity == null)
                {
                    _RemainingInaccessible = "";
                }
                else
                {
                    _RemainingInaccessible = (InaccessibleCapacity - GivenServiceMs.Count(x => x.VisitType == 19 && !x.Cancelled)).ToString();
                }

                return _RemainingInaccessible;
            }
            set { _RemainingInaccessible = value; }
        }


        private string _CapacityOrInfinite;

        public string CapacityOrInfinite
        {
            get
            {
                if (_CapacityOrInfinite == null)
                {
                    if (Capacity == 0)
                    {
                        _CapacityOrInfinite = "بدون محدودیت";
                    }
                    else if (Capacity == null)
                    {
                        _CapacityOrInfinite = "";
                    }
                    else
                    {
                        _CapacityOrInfinite = Capacity.ToString();
                    }
                }
                return _CapacityOrInfinite;
            }
            set { _CapacityOrInfinite = value; }
        }


    }


    public partial class Service
    {
        private float _Number;
        public float Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                if ((this._Number != value))
                {
                    this.SendPropertyChanging();
                    this._Number = value;
                    this.SendPropertyChanged("Number");
                }
            }
        }

    }
    public partial class GivenServiceD
    {
        private bool _Used;
        public bool Used
        {
            get
            {
                return this._Used;
            }
            set
            {
                if ((this._Used != value))
                {
                    this.SendPropertyChanging();
                    this._Used = value;
                    this.SendPropertyChanged("Used");
                }
            }
        }

    }
}
