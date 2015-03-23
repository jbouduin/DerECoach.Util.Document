using System;

namespace Bouduin.Lib.Holidays.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekendDay(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
