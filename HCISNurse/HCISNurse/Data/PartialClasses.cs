using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCISNurse.Classes;

namespace HCISNurse.Data
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

    public partial class QA
    {
        private Service _PService;

        public Service PService
        {
            get { return _PService; }
            set { _PService = value; }
        }

        private string _SortName;

        public string SortName
        {
            get { return _SortName; }
            set { _SortName = value; }
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

    public partial class FileExcel
    {
        private bool _IsHealthDiabet;

        public bool IsHealthDiabet
        {
            get { return _IsHealthDiabet; }
            set { _IsHealthDiabet = value; }
        }

        private bool _IsIFGDiabet;

        public bool IsIFGDiabet
        {
            get { return _IsIFGDiabet; }
            set { _IsIFGDiabet = value; }
        }

        private bool _IsIGTDiabet;

        public bool IsIGTDiabet
        {
            get { return _IsIGTDiabet; }
            set { _IsIGTDiabet = value; }
        }

        private bool _IsBloodFat;

        public bool IsBloodFat
        {
            get { return _IsBloodFat; }
            set { _IsBloodFat = value; }
        }

        private bool _IsBloodPressure;

        public bool IsBloodPressure
        {
            get { return _IsBloodPressure; }
            set { _IsBloodPressure = value; }
        }

        private bool _IsPreHypertension;

        public bool IsPreHypertension
        {
            get { return _IsPreHypertension; }
            set { _IsPreHypertension = value; }
        }

        private bool _IsObesity;

        public bool IsObesity
        {
            get { return _IsObesity; }
            set { _IsObesity = value; }
        }
    }
}
