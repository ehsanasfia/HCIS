using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCISAdmission
{

    public partial class GivenServiceM
    {

        private string _CreatorUser;
        public string CreatorUser
        {
            get
            {
                return _CreatorUser;
            }
            set
            {
                if ((this._CreatorUser != value))
                {
                    
                    this._CreatorUser = value;
                    
                }
            }
        }

    }



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

        private string _Zone;
        public string Zone
        {
            get
            {
                return this._Zone;
            }
            set
            {
                if ((this._Zone != value))
                {
                    this._Zone = value;
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

        private int _RemainingInteger;

        public int RemainingInteger
        {
            get
            {
                _RemainingInteger = Capacity - GivenServiceMs.Count(x => x.VisitType != 19 && !x.Cancelled) ?? 0;
                return _RemainingInteger;
            }
            set { _RemainingInteger = value; }
        }

        private int _RemainingInaccessibleInteger;

        public int RemainingInaccessibleInteger
        {
            get
            {
                _RemainingInaccessibleInteger = InaccessibleCapacity - GivenServiceMs.Count(x => x.VisitType == 19 && !x.Cancelled) ?? 0;
                return _RemainingInaccessibleInteger;
            }
            set { _RemainingInaccessibleInteger = value; }
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
}
