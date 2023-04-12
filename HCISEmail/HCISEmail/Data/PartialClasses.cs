using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISEmail.Data;
using HCISEmail.Classes;

namespace HCISEmail.Data
{
    public partial class User
    {
        private string _FullName;

        public string FullName
        {
            get
            {
                return this._FullName = this.IDUser + "." + this.FName + " " + this.LName;
            }
            set
            {
                if (this._FullName != value)
                {
                    this.OnFNameChanging(value);
                    this.SendPropertyChanging();
                    this._FullName = value;
                    this.SendPropertyChanged(FullName);
                    this.OnFNameChanged();
                }
            }
        }
    }
    public partial class sp_Email_Data_RecoveryResult
    {
        private string _Ago;

        public string Ago
        {
            get
            {
                var today = MainModule.GetPersianDate(DateTime.Now);
                var lastday = MainModule.GetPersianDate(DateTime.Now.AddDays(-1));
                var lastWeek = MainModule.GetPersianDate(DateTime.Now.AddDays(-7));
                var lastTwoWeek = MainModule.GetPersianDate(DateTime.Now.AddDays(-14));
                var lastThreeWeek = MainModule.GetPersianDate(DateTime.Now.AddDays(-21));
                var lastMonth = MainModule.GetPersianDate(DateTime.Now.AddDays(-30));
                if (this.CreationDate == today)
                    return this._Ago = "امروز";
                else if (this.CreationDate == lastday)
                    return this._Ago = "دیروز";
                else if (this.CreationDate.CompareTo(lastday) < 0 && this.CreationDate.CompareTo(lastWeek) > 0)
                    return this._Ago = MainModule.GetPersianDayOfWeek(MainModule.GetDateFromPersianString(this.CreationDate).DayOfWeek);
                else if (this.CreationDate.CompareTo(lastTwoWeek) > 0 && this.CreationDate.CompareTo(lastWeek) <= 0)
                    return this._Ago = "هفته گدشته";
                else if (this.CreationDate.CompareTo(lastThreeWeek) > 0 && this.CreationDate.CompareTo(lastTwoWeek) <= 0)
                    return this._Ago = "دو هفته گذشته";
                else
                    return this._Ago = "قدیمی";
            }
            set
            {
                this._Ago = value;
            }
        }

    }
}
