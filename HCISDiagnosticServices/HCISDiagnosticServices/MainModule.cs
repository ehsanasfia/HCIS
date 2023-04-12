﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCISDiagnosticServices.Data;

//using Newtonsoft.Json;
//using System.Net.Http;
using System.Net;
using System.IO;


namespace HCISDiagnosticServices
{
    public static class MainModule
    {
        public static Department InstallLocation { get; set; }
        private static ImageServerdbmlDataContext im;

        public static List<Study> StudiesOf(int SerialNumber)
        {
            if (im == null)
                im = new ImageServerdbmlDataContext();

            var imge = im.Studies.Where(x => x.PatientId.Contains(SerialNumber.ToString())).ToList();
            return imge;
        }

        public static Guid sonoStaffID;
        public static Guid mriStaffID;
        public static Guid sangStaffID;
        public static Guid ctStaffID;
        public static Guid radioStaffID;
        public static Guid mamoStaffID;

        static string Token = "";

        //static void gettoken()
        //{
        //    try
        //    {

        //        object input = new
        //        {
        //            Username = "his7nice",
        //            Password = "His@1234",
        //            ChallengeKey = ""
        //        };
        //        string serviceUrl = "http://172.30.1.80/metric/api/token/generatetoken";
        //        // string PrivateKey = "987455124";//"987455124";
        //        try
        //        {
        //            string inputJson = JsonConvert.SerializeObject(input);
        //            HttpClient client = new HttpClient();
        //            //  client.DefaultRequestHeaders.Add("PrivateKey", PrivateKey);
        //            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.PostAsync(serviceUrl, inputContent).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                byte[] bytes = response.Content.ReadAsByteArrayAsync().Result;
        //                string utfString = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        //                var result = JsonConvert.DeserializeObject<string>(utfString, new JsonSerializerSettings
        //                {
        //                    NullValueHandling = NullValueHandling.Ignore
        //                });
        //                Token = result;
        //            }
        //        }
        //        catch (Exception exc)
        //        { }
        //        //  Application.DoEvents();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //public static string GetServerMarkoPacs(string PatientID)
        //{
        //    if (Token == "")
        //        gettoken();
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://172.30.1.80");
        //            var response = client.GetAsync($"metric/api/study/exist?mdl.patientId=" + PatientID + "&mdl.token=" + Token).Result;
        //            if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                return "OK";
        //            }
        //            else
        //            {
        //                return response.StatusCode.ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //   MessageBox.Show(ex.Message);
        //        return "NO";
        //    }

        //}

        #region Persian Date


        private static System.Globalization.PersianCalendar _cal = new System.Globalization.PersianCalendar();
        public enum PersianDateType
        {
            Simple = 1,
            Full = 2
        }

        static internal int GetAge(System.DateTime _date)
        {
            return Convert.ToInt32(Math.Truncate((decimal)(System.DateTime.Now - _date).Days / 365));
        }

        //First And Last date of month and year
        static internal string GetPersianFirstDateOfMonth(System.DateTime _date, PersianDateType format = PersianDateType.Simple, char Seperator = '/')
        {
            string SimpleDate = _cal.GetYear(_date).ToString("0000") + Seperator + _cal.GetMonth(_date).ToString("00") + Seperator + "01";
            switch (format)
            {
                case PersianDateType.Simple:
                    return SimpleDate;
                case PersianDateType.Full:
                    return GetLongPersianDate(GetDateFromPersianString(SimpleDate), Seperator);
                default:
                    return SimpleDate;
            }
        }
        static internal string GetPersianFirstDateOfYear(System.DateTime _date, PersianDateType format = PersianDateType.Simple, char Seperator = '/')
        {
            string SimpleDate = _cal.GetYear(_date).ToString("0000") + Seperator + "01" + Seperator + "01";
            switch (format)
            {
                case PersianDateType.Simple:
                    return SimpleDate;
                case PersianDateType.Full:
                    return GetLongPersianDate(GetDateFromPersianString(SimpleDate), Seperator);
                default:
                    return SimpleDate;
            }
        }
        static internal string GetPersianLastDateOfMonth(System.DateTime _date, PersianDateType format = PersianDateType.Simple, char Seperator = '/')
        {
            string SimpleDate = _cal.GetYear(_date).ToString("0000") + Seperator + _cal.GetMonth(_date).ToString("00") + Seperator + GetPersianLastDayOfMonth(_date).ToString("00");
            switch (format)
            {
                case PersianDateType.Simple:
                    return SimpleDate;
                case PersianDateType.Full:
                    return GetLongPersianDate(GetDateFromPersianString(SimpleDate), Seperator);
                default:
                    return SimpleDate;
            }
        }
        static internal string GetPersianLastDateOfYear(System.DateTime _date, PersianDateType format = PersianDateType.Simple, char Seperator = '/')
        {
            string SimpleDate = _cal.GetYear(_date).ToString("0000") + Seperator + "12" + Seperator + GetPersianLastDayOfMonth(_cal.GetYear(_date), 12).ToString("00");
            switch (format)
            {
                case PersianDateType.Simple:
                    return SimpleDate;
                case PersianDateType.Full:
                    return GetLongPersianDate(GetDateFromPersianString(SimpleDate), Seperator);
                default:
                    return SimpleDate;
            }
        }
        static internal byte GetPersianLastDayOfMonth(System.DateTime _date, PersianDateType _type = PersianDateType.Simple)
        {
            return GetPersianLastDayOfMonth(_cal.GetYear(_date), _cal.GetMonth(_date), _type);
        }
        static internal byte GetPersianLastDayOfMonth(int Year, int Month, PersianDateType _type = PersianDateType.Simple)
        {
            if (Month < 7)
            {
                return 31;
            }
            else
            {
                if (Month < 12 || _cal.IsLeapYear(Year))
                    return 30;
            }
            return 29;
        }

        //Convert Persian String Date To Date
        static internal System.DateTime GetDateFromPersianString(string _dateStr, char DateSplitter = '/')
        {
            try
            {
                return GetDateFromPersianString(_dateStr, "00:00", DateSplitter);
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }
        static internal System.DateTime GetDateFromPersianString(string _dateStr, string _timeStr, char DateSplitter = '/', char timeSplitter = ':')
        {
            try
            {
                string[] oDate = _dateStr.Split(DateSplitter);
                string[] oTime = _timeStr.Split(timeSplitter);
                return new System.DateTime(Convert.ToInt32(oDate[0]), Convert.ToInt32(oDate[1]), Convert.ToInt32(oDate[2]), Convert.ToInt32(oTime[0]), Convert.ToInt32(oTime[1]), 0, 0, new System.Globalization.PersianCalendar());
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

        //Convert Date To Persian String Date
        static internal string GetPersianDate(System.DateTime _date, PersianDateType format = PersianDateType.Simple, char Seperator = '/')

        {
            switch (format)
            {
                case PersianDateType.Simple:
                    return GetShortPersianDate(_date, Seperator);
                case PersianDateType.Full:
                    return GetLongPersianDate(_date, Seperator);
                default:
                    return GetShortPersianDate(_date, Seperator);
            }
        }
        private static string GetShortPersianDate(System.DateTime _date, char Seperator = '/')
        {
            return _cal.GetYear(_date).ToString("0000") + Seperator + _cal.GetMonth(_date).ToString("00") + Seperator + _cal.GetDayOfMonth(_date).ToString("00");
        }
        private static string GetLongPersianDate(System.DateTime _date, char Seperator = ' ')
        {
            return GetPersianDayOfWeek(_date.DayOfWeek) + Seperator + GetPersianDayOfMonthText(_date) + Seperator + GetPersianMonthName(_date) + Seperator + "ماه" + Seperator + "سال" + Seperator + _cal.GetYear(_date).ToString("0000");
        }

        //Base Functions
        static internal string GetPersianDayOfWeek(DayOfWeek _day)
        {
            switch (_day)
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                case DayOfWeek.Monday:
                    return "دوشنبه";
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                case DayOfWeek.Thursday:
                    return "پنج شنبه";
                case DayOfWeek.Friday:
                    return "جمعه";
                default:
                    return "";
            }
        }
        static internal string GetPersianDayOfMonthText(System.DateTime _date)
        {
            return GetPersianDayOfMonthText(_cal.GetDayOfMonth(_date));
        }
        static internal string GetPersianDayOfMonthText(int _day)
        {
            switch (_day)
            {
                case 1:
                    return "یکم";
                case 2:
                    return "دوم";
                case 3:
                    return "سوم";
                case 4:
                    return "چهارم";
                case 5:
                    return "پنجم";
                case 6:
                    return "ششم";
                case 7:
                    return "هفتم";
                case 8:
                    return "هشتم";
                case 9:
                    return "نهم";
                case 10:
                    return "دهم";
                case 11:
                    return "یازدهم";
                case 12:
                    return "دوازدهم";
                case 13:
                    return "سیزدهم";
                case 14:
                    return "چهاردهم";
                case 15:
                    return "پانزدهم";
                case 16:
                    return "شانزدهم";
                case 17:
                    return "هفدهم";
                case 18:
                    return "هجدهم";
                case 19:
                    return "نوزدهم";
                case 20:
                    return "بیستم";
                case 21:
                    return "بیست و یکم";
                case 22:
                    return "بیست و دوم";
                case 23:
                    return "بیست و سوم";
                case 24:
                    return "بیست و چهارم";
                case 25:
                    return "بیست و پنجم";
                case 26:
                    return "بیست و ششم";
                case 27:
                    return "بیست و هفتم";
                case 28:
                    return "بیست و هشتم";
                case 29:
                    return "بیست و نهم";
                case 30:
                    return "سی ام";
                case 31:
                    return "سی و یکم";
                default:
                    return "";
            }
        }
        static internal string GetPersianMonthName(System.DateTime _date)
        {
            return GetPersianMonthName(_cal.GetMonth(_date));
        }
        static internal string GetPersianMonthName(int _month)
        {
            switch (_month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }

        static internal string GetChristianMonthName(int _month)
        {
            switch (_month)
            {
                case 1:
                    return "ژانویه";
                case 2:
                    return "فبریه";
                case 3:
                    return "مارس";
                case 4:
                    return "آپریل";
                case 5:
                    return "می";
                case 6:
                    return "ژوئن";
                case 7:
                    return "جولای";
                case 8:
                    return "آگوست";
                case 9:
                    return "سپتامبر";
                case 10:
                    return "اکتبر";
                case 11:
                    return "نوامبر";
                case 12:
                    return "دسامبر";
                default:
                    return "";
            }
        }
        #endregion
        #region Users
        //static public int EmployeeID
        //{
        //    get
        //    {
        //        var dc = new Data.EHPlacesDataContext();
        //        var employee = dc.EmployeeUsers.Where(c => c.UserID == UserID).FirstOrDefault();
        //        var result = 0;
        //        if (employee != null)
        //            result = employee.EmployeeID;
        //        return result;
        //    }
        //}

        public static void SetApplicationNameForConnectionString(string connectionName)
        {
            var conn = Properties.Settings.Default[connectionName].ToString();
            var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(conn);
            builder.ApplicationName = String.Format("User={0};UserID={1};ApplicationName={2}", UserName, UserID, typeof(Program).Assembly.GetName().Name);
            builder.ApplicationName = builder.ApplicationName.Length > 128 ? builder.ApplicationName.Substring(0, 128) : builder.ApplicationName;
            Properties.Settings.Default[connectionName] = builder.ConnectionString;
        }
        static private string userName = "administrator";
        static public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        static private int appID = 0;

        static public int AppID
        {
            get { return appID; }
            set { appID = value; }
        }
        static private int userID = 1;
        static public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        static private Service  diagnosticServices;
        static public Service DiagnosticService
        {
            get { return diagnosticServices; }
            set { diagnosticServices = value; }
        }
        static private int roleID = 1;

        static public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }
        static private string roleName = "administrator";
        static public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        static string userFullName = "مدیر سیستم";
        static public string UserFullName
        {
            get
            {
                return userFullName;
            }
            set
            {
                userFullName = value;
            }
        }
        #endregion

    }
}
