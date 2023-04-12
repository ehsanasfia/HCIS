using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMOApp.Data;
using OMOApp.Classes;
using OMOApp.Data.HCISData;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OMOApp.Classes
{
    public static class MainModule
    {
        public static Guid HarmfulFactorsParent = Guid.Parse("b3d4de15-71f1-48d1-96f5-959925c4fc97");

        public static Visit VST_Set { get; set; }

        private static imageDataContext im;

        public static Data.Staff MyStaff { get; set; }

        public static List<Study> StudiesOf(int SerialNumber)
        {
            if (im == null)
                im = new imageDataContext();
            List<Study> imge = new List<Study>();

            var studySeial = im.StudySerials.Where(x => x.SerialNumber == SerialNumber).ToList();
            if (studySeial.Any())
            {
                studySeial.ForEach(x =>
                {
                    var std = im.Studies.FirstOrDefault(y => y.GUID == x.StudyID);
                    if (std != null)
                        imge.Add(std);
                });
            }

            return imge;
        }

        public static void EndOfVisit(List<Visit> lstVisits)
        {
            foreach (var item in lstVisits)
            {
                if (item.ToDoList != null)
                {
                    if (item.ToDoList.Audio == true &&
                      item.ToDoList.Checkup == true &&
                      item.ToDoList.HarmfulFactor == true &&
                      item.ToDoList.MedicalHistory == true &&
                      item.ToDoList.Nursing == true &&
                      item.ToDoList.Optometry == true &&
                      item.ToDoList.Psychology == true &&
                      item.ToDoList.Result == true &&
                      item.ToDoList.Spirometry == true &&
                      item.ToDoList.Surveillance == true)
                    {
                        item.EndOfVisit = true;
                    }
                    else
                        item.EndOfVisit = false;
                }
                else
                    item.EndOfVisit = false;
            }
        }

        public static Image GetImageFromBinary(System.Data.Linq.Binary BinaryPhoto)
        {
            Image image = null;
            if (BinaryPhoto != null)
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    var data = BinaryPhoto.ToArray();
                    ms.Write(data, 0, data.Length);
                    ms.Flush();
                    image = Image.FromStream(ms);
                }
            }
            else
                image = null;

            return image;
        }

        public static bool IsValidNationalCode(string nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد

            if (String.IsNullOrEmpty(nationalCode))
                return false;


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                return false;

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                return false;

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode))
                return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        public static string CreateMedicalID(int? PersonalCode)
        {
            if (PersonalCode == null || !PersonalCode.HasValue || PersonalCode.Value <= 0)
                return null;

            return "00-" + PersonalCode.Value.ToString("0000000") + "-01";
        }

        public static string PersonalNoToString(int? PersonalNo)
        {
            if (PersonalNo == null || !PersonalNo.HasValue || PersonalNo.Value <= 0)
                return null;

            return PersonalNo.Value.ToString().Trim();
        }

        #region DataContext
        static internal bool DataContextChanged(System.Data.Linq.DataContext dc)
        {
            try
            {
                return (dc.GetChangeSet().Inserts.Count > 0 || dc.GetChangeSet().Deletes.Count > 0 || dc.GetChangeSet().Updates.Count > 0);

            }
            catch (Exception)
            {
                return false;
            }
        }
     
        #endregion
        #region LayoutControl

        internal static void MakeReadOnly(DevExpress.XtraLayout.LayoutControlGroup lcg, bool SetReadOnly = true)
        {
            foreach (DevExpress.XtraLayout.LayoutControlItem item in lcg.Items.OfType<DevExpress.XtraLayout.LayoutControlItem>())
            {
                if (item.Control != null)
                {
                    item.Control.TabStop = !SetReadOnly;

                    switch (item.Control.GetType().ToString())
                    {
                        case "DevExpress.XtraEditors.TextEdit":
                            ((DevExpress.XtraEditors.TextEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.ComboBoxEdit":
                            ((DevExpress.XtraEditors.ComboBoxEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.LookUpEdit":
                            ((DevExpress.XtraEditors.LookUpEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.MemoEdit":
                            ((DevExpress.XtraEditors.MemoEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.CheckEdit":
                            ((DevExpress.XtraEditors.CheckEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.RadioGroup":
                            ((DevExpress.XtraEditors.RadioGroup)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.SpinEdit":
                            ((DevExpress.XtraEditors.SpinEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraEditors.SearchLookUpEdit":
                            ((DevExpress.XtraEditors.SearchLookUpEdit)item.Control).Properties.ReadOnly = SetReadOnly;
                            break;
                        case "DevExpress.XtraGrid.GridControl":
                            if (SetReadOnly)
                            {
                                ((DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)item.Control).MainView).OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                                ((DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)item.Control).MainView).OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                            }
                            else
                            {
                                ((DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)item.Control).MainView).OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                                ((DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)item.Control).MainView).OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                            }
                            ((DevExpress.XtraGrid.Views.Grid.GridView)((DevExpress.XtraGrid.GridControl)item.Control).MainView).OptionsBehavior.Editable = !SetReadOnly;
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (DevExpress.XtraLayout.LayoutControlGroup grpitem in lcg.Items.OfType<DevExpress.XtraLayout.LayoutControlGroup>())
            {
                MakeReadOnly(grpitem, SetReadOnly);
            }
            foreach (DevExpress.XtraLayout.TabbedControlGroup tabbeditem in lcg.Items.OfType<DevExpress.XtraLayout.TabbedControlGroup>())
            {
                foreach (var item in tabbeditem.TabPages)
                {
                    MakeReadOnly((DevExpress.XtraLayout.LayoutControlGroup)item, SetReadOnly);
                }
            }
        }


        #endregion
        #region GridFocus
        static internal void GridViewRightToLeft(object sender, KeyEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView view;
                if (sender.GetType() == typeof(DevExpress.XtraGrid.Views.Grid.GridView))
                {
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                }
                else if (sender.GetType() == typeof(DevExpress.XtraGrid.GridControl))
                {
                    var grid = (DevExpress.XtraGrid.GridControl)sender;
                    if (grid.FocusedView.GetType() == typeof(DevExpress.XtraGrid.Views.Grid.GridView))
                    {
                        view = (DevExpress.XtraGrid.Views.Grid.GridView)grid.FocusedView;
                    }
                    else return;
                }
                else return;


                var lowerIndexCol = from DevExpress.XtraGrid.Columns.GridColumn col in view.Columns
                                    where col.VisibleIndex < view.FocusedColumn.VisibleIndex && col.OptionsColumn.AllowFocus == true
                                    orderby col.VisibleIndex descending
                                    select col;
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    view.ValidateEditor();
                    view.CloseEditor();
                    view.BeginUpdate();
                    if (view.FocusedColumn == null) return;

                    if (lowerIndexCol.Count() > 0)
                    {
                        view.FocusedColumn = lowerIndexCol.ToList()[0];
                    }
                    else
                    {

                        view.UpdateCurrentRow();
                        view.MoveNext();

                        var columns = from DevExpress.XtraGrid.Columns.GridColumn col in view.Columns
                                      where col.OptionsColumn.AllowFocus == true
                                      orderby col.VisibleIndex descending
                                      select col;
                        if (columns.Count() > 0)
                        {
                            view.FocusedColumn = columns.ToList()[0];
                        }
                    }
                    e.SuppressKeyPress = true;
                    view.EndUpdate();
                }
            }
            catch (Exception)
            {

            }
        }
        static internal void GridEnterRightToLeft(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;
            if (sender.GetType() == typeof(DevExpress.XtraGrid.Views.Grid.GridView))
            {
                view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            }
            else if (sender.GetType() == typeof(DevExpress.XtraGrid.GridControl))
            {
                var grid = (DevExpress.XtraGrid.GridControl)sender;
                if (grid.MainView.GetType() == typeof(DevExpress.XtraGrid.Views.Grid.GridView))
                {
                    view = (DevExpress.XtraGrid.Views.Grid.GridView)grid.MainView;
                }
                else return;
            }
            else return;

            var columns = from DevExpress.XtraGrid.Columns.GridColumn col in view.Columns
                          where col.OptionsColumn.AllowFocus == true
                          orderby col.VisibleIndex descending
                          select col;
            if (columns.Count() > 0)
            {
                view.FocusedColumn = columns.ToList()[0];
            }
        }
        #endregion
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
        //static private Department mydepartment;
        //static public Department MyDepartment
        //{
        //    get { return mydepartment; }
        //    set { mydepartment = value; }
        //}
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
        //static private Service  diagnosticServices;
        //static public Service DiagnosticService
        //{
        //    get { return diagnosticServices; }
        //    set { diagnosticServices = value; }
        //}
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
        static public string LastName
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

    
        public static bool ConnectToHcis { get; internal set; }
        #endregion
        #region EditorValidation

        internal static void EditorValidate(object sender, DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ErrorProvider, System.ComponentModel.CancelEventArgs e)
        {
            if (((DevExpress.XtraEditors.BaseEdit)sender).EditValue == DBNull.Value)
            {
                e.Cancel = true;
            }
            else
                try
                {
                    if (((DevExpress.XtraEditors.BaseEdit)sender).EditValue.ToString().Length == 0 || (int)((DevExpress.XtraEditors.BaseEdit)sender).EditValue == 0)
                        e.Cancel = true;
                }
                catch (Exception) { }

            if (e.Cancel)
            {
                e.Cancel = false;
                ErrorProvider.SetError((DevExpress.XtraEditors.BaseEdit)sender, "نمیتواند خالی باشد\nلطفاً مقدار را وارد نمایید", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
            {
                ErrorProvider.SetError((DevExpress.XtraEditors.BaseEdit)sender, "", DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            }
        }
        #endregion
    }
}
