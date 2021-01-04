using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Utilities
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
        }
        public static DateTime ToMiladi(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 0, new System.Globalization.PersianCalendar());
        }
        public static DateTime ToMiladiStartDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0,0,1, 0, new System.Globalization.PersianCalendar());
        }
        public static DateTime ToMiladiEndDay(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 0, new System.Globalization.PersianCalendar());
        }
        public static DateTime ToMiladistringStartDay(string dateTime)
        {
            PersianCalendar p = new PersianCalendar();

            string[] parts = dateTime.Split('/', '-');
            DateTime dt = p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0, 0, 0);
            return dt;

        }
        public static DateTime ToMiladistringEndDay(string dateTime)
        {
            PersianCalendar p = new PersianCalendar();

            string[] parts = dateTime.Split('/', '-');
            DateTime dt = p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 23, 59, 59, 0);
            return dt;

        }
        public static string ToShamsiDateTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00") + " " + pc.GetHour(value).ToString("00") + ":" + pc.GetMinute(value).ToString("00");
        }

        internal static DateTime? ToMiladi(DateTime? returnDate)
        {
            throw new NotImplementedException();
        }
    }
}