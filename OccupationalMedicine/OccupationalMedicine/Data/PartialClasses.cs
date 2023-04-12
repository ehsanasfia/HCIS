using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OccupationalMedicine.Data
{
    public partial class Person
    {
        private bool _InComplete;

        public bool InComplete
        {
            get
            {
                return this._InComplete;
            }
            set
            {
                if ((this._InComplete != value))
                {
                    this.SendPropertyChanging();
                    this._InComplete = value;
                    this.SendPropertyChanged("InComplete");
                }
            }
        }

        private HashSet<int> _InCompleteIndexes;

        public HashSet<int> InCompleteIndexes
        {
            get
            {
                if (_InCompleteIndexes == null)
                {
                    _InCompleteIndexes = new HashSet<int>();
                }
                return _InCompleteIndexes;
            }
            set
            {
                if ((this._InCompleteIndexes != value))
                {
                    this.SendPropertyChanging();
                    this._InCompleteIndexes = value;
                    this.SendPropertyChanged("InCompleteIndexes");
                }
            }
        }

        private int _ExcelIndex;

        public int ExcelIndex
        {
            get
            {
                return _ExcelIndex;
            }
            set
            {
                if ((this._ExcelIndex != value))
                {
                    this.SendPropertyChanging();
                    this._ExcelIndex = value;
                    this.SendPropertyChanged("ExcelIndexes");
                }
            }
        }

    }
    public partial class TestAnswerFile
    {
        public String SerialNumber { set; get; }
        public String Answer { set; get; }
        public String Name { set; get; }
        public String Cat { set; get; }

        public int Index { set; get; }
    }

    public partial class PersonWorkHistory
    {
        private string _SubmittedStatus;

        public string SubmittedStatus
        {
            get { return _SubmittedStatus; }
            set { _SubmittedStatus = value; }
        }

    }

    public partial class VwDiabeteTypePercentage
    {
        private decimal _Percentage;

        public decimal Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; }
        }

    }
}

