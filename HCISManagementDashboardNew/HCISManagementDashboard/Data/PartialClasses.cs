using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISManagementDashboard.Data
{
    partial class Spu_DoctorTimesAndStandardsResult
    {
        private string _Time;

        public string Time
        {
            get
            {
                if (SumTimeExists == null || !SumTimeExists.HasValue)
                    return "000:00:00";

                int sum = SumTimeExists.Value;
                
                int minutes = 0;
                int hours = 0;

                hours = sum / 60;
                sum %= 60;

                minutes = sum;

                _Time = hours.ToString("000") + ":" + minutes.ToString("00") + ":00";

                return _Time;
            }
            set { _Time = value; }
        }

    }

    partial class Department
    {
        private string _FullName;

        public string FullName
        {
            get
            {
                if (_FullName == null)
                {
                    string parentName = (Department1 == null || string.IsNullOrWhiteSpace(Department1.Name) ? null : Department1.Name.Trim());
                    bool hasParentName = (parentName != null);
                    string depName = Name?.Trim();

                    _FullName = depName;
                    if (TypeID == 10) //Clinics
                    {
                        _FullName = "کلینیک " + depName + " " + (parentName ?? "");
                    }
                    else if (TypeID == 52) // Laboratory
                    {
                        _FullName = depName?.Replace("بیمارستان", "").Replace("درمانگاه", "").Trim() + " " + parentName;
                    }
                    else if (TypeID == 11)
                    {
                        _FullName = "بخش " + depName + " " + parentName;
                    }
                    else if (TypeID == 12)
                    {
                        _FullName = "داروخانه " + depName.Replace("داروخانه", "").Trim();
                    }
                    else if (TypeID == 555)
                    {
                        _FullName = depName + " بیمارستان";
                    }

                    if (string.IsNullOrWhiteSpace(_FullName))
                        _FullName = depName;
                    else
                        _FullName = _FullName.Trim();
                }

                return _FullName;
            }
            set
            {
                _FullName = value;
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

        private int age;
        public int Age

        {
            set { this.age = value; /*Classes.MainModule.GetAge(Classes.MainModule.GetDateFromPersianString(this.BirthDate))*/; }
            get { return this.age = MainModule.GetAge(MainModule.GetDateFromPersianString(this.BirthDate)); }
        }
    }

    public partial class View_SarpaeiServiceUnion
    {
        private string _MyDate;

        public string MyDate
        {
            get { return _MyDate; }
            set { _MyDate = value; }
        }

        private string _MyDep;

        public string MyDep
        {
            get { return _MyDep; }
            set { _MyDep = value; }
        }
    }

    public partial class Vw_BastariPatientAll
    {
        private string _DischargeDate;

        public string DischargeDate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Date))
                {
                    DischargeDate = "";
                }
                else
                {

                    var admit = MainModule.GetDateFromPersianString(Date.Trim());
                    var add = admit.AddDays(CountH);
                    DischargeDate = MainModule.GetPersianDate(add);
                }

                return _DischargeDate;
            }
            set { _DischargeDate = value; }
        }
    }
}
