using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCISTriage.Data
{
    public partial class Spu_TriageShakhesAllResult
    {
        private string _StandardTime;

        public string StandardTime
        {
            get
            {
                bool isnull = (Result == null || !Result.HasValue);
                if (isnull)
                    _StandardTime = "";
                else
                {
                    switch (ShakhesNumber)
                    {
                        case 1:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 2:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 3:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 4:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 5:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 6:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 7:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 8:
                            _StandardTime = string.Format("{0:n0}", Result);
                            break;
                        case 9:
                            _StandardTime = string.Format("{0:n0}", Result);
                            break;
                        case 10:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 11:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 12:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 13:
                            _StandardTime = string.Format("{0:n2}%", Result);
                            break;
                        case 14:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 15:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 16:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 17:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        case 18:
                            _StandardTime = TimeSpan.FromSeconds(Result.Value).ToString(@"h\ \س\ا\ع\ت\ \و\ m\ \د\ق\ی\ق\ه\ \و\ s\ \ث\ا\ن\ی\ه");
                            break;
                        default:
                            _Name = "";
                            break;
                    }
                }
                return _StandardTime;
            }
            set
            {
                _StandardTime = value;
            }
        }


        private string _Name;

        public string Name
        {
            get
            {
                if (_Name == null)
                {
                    switch (ShakhesNumber)
                    {
                        case 1:
                            _Name = "درصد بیماران تعیین تکلیف شده ظرف مدت 6 ساعت";
                            break;
                        case 2:
                            _Name = "میانگین زمانی تعیین تکلیف بیماران";
                            break;
                        case 3:
                            _Name = "میانه زمانی تعیین تکلیف بیماران";
                            break;
                        case 4:
                            _Name = "درصد بیماران خارج شده از اورژانس ظرف مدت 12 ساعت";
                            break;
                        case 5:
                            _Name = "میانگین زمانی خروج بیماران بستری شده از اورژانس";
                            break;
                        case 6:
                            _Name = "میانه زمانی خروج بیماران بستری شده از اورژانس";
                            break;
                        case 7:
                            _Name = "درصد CPR موفق";
                            break;
                        case 8:
                            _Name = "تعداد کل موارد CPR";
                            break;
                        case 9:
                            _Name = "تعداد موارد CPR موفق";
                            break;
                        case 10:
                            _Name = "درصد CPR موفق بیماران ترومایی";
                            break;
                        case 11:
                            _Name = "درصد CPR موفق بیماران داخلی";
                            break;
                        case 12:
                            _Name = "درصد CPR موفق بیماران فاقد علایم حیاتی قبل از بیمارستان";
                            break;
                        case 13:
                            _Name = "درصد ترک با مسئولیت شخصی";
                            break;
                        case 14:
                            _Name = "میانگین مدت زمان انتظار بیماران برای اولین ویزیت پزشک در سطح یک تریاژ";
                            break;
                        case 15:
                            _Name = "میانگین مدت زمان انتظار بیماران برای اولین ویزیت پزشک در سطح دو تریاژ";
                            break;
                        case 16:
                            _Name = "میانگین مدت زمان انتظار بیماران برای اولین ویزیت پزشک در سطح سه تریاژ";
                            break;
                        case 17:
                            _Name = "میانگین مدت زمان انتظار بیماران برای اولین ویزیت پزشک در سطح چهار تریاژ";
                            break;
                        case 18:
                            _Name = "میانگین مدت زمان انتظار بیماران برای اولین ویزیت پزشک در سطح پنج تریاژ";
                            break;
                        default:
                            _Name = "";
                            break;
                    }
                }
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

    }
}
