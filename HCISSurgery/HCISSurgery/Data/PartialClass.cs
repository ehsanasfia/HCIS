using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISSurgery.Data
{
    public partial class Service
    {
        private bool _Finance;
        private string _Comment;
        private float _Amount;
        private float _Number;
        private DrugFrequencyUsage _HIX;
        private bool _MustHavePrice;

        public bool Finance
        {
            get { return _Finance; }
            set { _Finance = value; }
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

        private bool _isNIS;

        public bool IsNIS
        {
            get { return _isNIS; }
            set { _isNIS = value; }
        }

        private double? _JF;

        public double? JF
        {
            get { return _JF; }
            set { _JF = value; }
        }
        private double? _JH;

        public double? JH
        {
            get { return _JH; }
            set { _JH = value; }
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
    }
}
