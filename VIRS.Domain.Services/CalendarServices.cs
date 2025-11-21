using System.Globalization;
using VIRS.Domain.Core.Calendar.Contracts.Services;

namespace VIRS.Domain.Services
{
    public class CalendarServices(
        PersianCalendar pc) : ICalendarServices
    {
        public int ShamsiDayOfWeek(DateTime date)
            => ((int)date.DayOfWeek + 1) % 7;

        public string ShamsiDayNameOfWeek(int dayNumber)
        {
            switch (dayNumber)
            {
                case 0:
                    return "شنبه";
                case 1:
                    return "یکشنبه";
                case 2:
                    return "دوشنبه";
                case 3:
                    return "سه‌شنبه";
                case 4:
                    return "چهارشنبه";
                case 5:
                    return "پنجشنبه";
                case 6:
                    return "جمعه";
            }
            return "نامعتبر";
        }
        public string ShamsiMonthName(int monthNumber)
        {
            switch (monthNumber)
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
            }
            return "نامعتبر";
        }

        public string CompleteShamsiDate(DateTime date)
        {
            var dayOfWeek = ShamsiDayOfWeek(date);
            var monthNumber = pc.GetMonth(date);

            return $" {ShamsiDayNameOfWeek(dayOfWeek)}، " +
                   $" {pc.GetDayOfMonth(date)} " +
                   $" {ShamsiMonthName(monthNumber)} ماه " +
                   $"سال {pc.GetYear(date)}";
        }
    }
}
