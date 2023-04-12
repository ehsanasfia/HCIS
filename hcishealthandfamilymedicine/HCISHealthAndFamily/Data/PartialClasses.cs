using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISHealthAndFamily.Classes;

namespace HCISHealthAndFamily.Data
{


    public partial class Service
    {
        private string _Comment;
        private float _Amount;
        private float _Number;
        private DrugFrequencyUsage _HIX;
        private string _O2Comment;
        private string _BloodComment;
        private string _Test;

        public string Test
        {
            get
            {
                return this.LaboratoryServiceDetail.AbbreviationName + "  " + "(" + Name + ")";
            }

        }

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
        public string O2Comment
        {
            get
            {
                return this._O2Comment;
            }
            set
            {
                if ((this._O2Comment != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._O2Comment = value;
                    this.SendPropertyChanged("O2Comment");
                    this.OnNameChanged();
                }
            }
        }

        public string BloodComment
        {
            get
            {
                return this._BloodComment;
            }
            set
            {
                if ((this._BloodComment != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._BloodComment = value;
                    this.SendPropertyChanged("BloodComment");
                    this.OnNameChanged();
                }
            }
        }

        private bool _MustHavePrice;

        public bool MustHavePrice
        {
            get { return _MustHavePrice; }
            set { _MustHavePrice = value; }
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
                    this.OnNameChanging(value.ToString());
                    this.SendPropertyChanging();
                    this._Number = value;
                    this.SendPropertyChanged("Number");
                    this.OnNameChanged();
                }
            }
        }

        private Service _Partial_LabParent;

        public Service Partial_LabParent
        {
            get { return _Partial_LabParent; }
            set { _Partial_LabParent = value; }
        }

        private bool _isNIS;

        public bool IsNIS
        {
            get { return _isNIS; }
            set { _isNIS = value; }
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
                    this._FullName = value;
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

    public partial class QAPlus
    {
        private Questionnaire _PQuestionnaire;

        public Questionnaire PQuestionnaire
        {
            get { return _PQuestionnaire; }
            set { _PQuestionnaire = value; }
        }

        private string _SortName;

        public string SortName
        {
            get { return _SortName; }
            set { _SortName = value; }
        }
    }

    public partial class AlarmDetail
    {
        private Service _PService;

        public Service PService
        {
            get { return _PService; }
            set { _PService = value; }
        }

    }

}
