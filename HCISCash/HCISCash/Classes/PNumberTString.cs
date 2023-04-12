using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace HCISCash.Classes
{

    public class PNumberTString
    {

        private static string[] yakan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };

        private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };

        private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };

        private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };

        private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };

        private static string getnum3(int num3)

        {

            string s = "";

            int d3, d12;

            d12 = num3 % 100;

            d3 = num3 / 100;

            if (d3 != 0)

                s = sadgan[d3] + " و ";

            if ((d12 >= 10) && (d12 <= 19))
            {

                s = s + dahyek[d12 - 10];

            }

            else
            {

                int d2 = d12 / 10;

                if (d2 != 0)

                    s = s + dahgan[d2] + " و ";

                int d1 = d12 % 10;

                if (d1 != 0)

                    s = s + yakan[d1] + " و ";

                s = s.Substring(0, s.Length - 3);

            };

            return s;

        }

        static string int2str(string snum)
        {

            string stotal = "";

            if (snum == "") return "";

            if (snum == "0")
            {

                return yakan[0];

            }

            else
            {

                snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');

                int L = snum.Length / 3 - 1;

                for (int i = 0; i <= L; i++)
                {

                    int b = int.Parse(snum.Substring(i * 3, 3));

                    if (b != 0)

                        stotal = stotal + getnum3(b) + " " + basex[L - i] + " و ";

                }

                stotal = stotal.Substring(0, stotal.Length - 3);

            }

            return stotal;

        }

        public static string GetStr(string number)
        {
            if (number.Contains("/"))
               number= number.Replace("/", ".");
            if (!number.Contains("."))

                return int2str(number);

            else
            {

                string[] str = number.Split('.');
                string result = int2str(str[0]);
                string right = str[1].TrimEnd(new char[] { '0' });
                if (right.Length > 0)
                {
                    result += "ممیز ";
                }

                result += int2str(right);

                switch (right.Length)
                {

                    case 1:

                        result += " دهم ";

                        break;

                    case 2:

                        result += " صدم ";

                        break;

                    case 3:

                        result += " هزارم ";

                        break;

                    case 4:

                        result += " ده هزارم ";

                        break;
                    case 5:

                        result += " صد هزارم ";

                        break;

                    default:

                        break;

                }
                return result;
            }

        }
        public static  string date2fa(string dateT)
        {
            string[] strData = new string[4];
            strData = dateT.Split('/');
            strData[0] = GetStr(strData[0]);
            strData[1] = munth2fa(strData[1]);

            strData[2] = GetStr(strData[2]);
            return strData[2]+" "+ strData[1] + " " + strData[0];

        }
        private static  string munth2fa(string dateT)
        {

            switch (dateT)
            {
                case "01":
                    return "فروردین";
                case "02":
                    return "ادریبهشت";
                case "03":
                    return "خرداد";
                case "04":
                    return "تیر";
                case "05":
                    return "مرداد";
                case "06":
                    return "شهریور";
                case "07":
                    return "مهر";
                case "08":
                    return "ابان";
                case "09":
                    return "اذر";
                case "10":
                    return "دی";
                case "11":
                    return "بهمن";
                case "12":
                    return "اسفند";
                default:
                    return "You typed something else";
            }



        }

    }
}
