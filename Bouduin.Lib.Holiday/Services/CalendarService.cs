using System;
using System.Linq;
using Bouduin.Lib.Holidays.Configurations;

namespace Bouduin.Lib.Holidays.Services
{
    internal class CalendarService: ICalendarService
    {
        #region ICalendarService methods --------------------------------------
        public bool IsValid(Holiday holiday,int year)
        {
            var result = (holiday.validFrom < year || holiday.validFrom <= 0) &&
                   (holiday.validTo > year || holiday.validTo == 0) && IsValidForCyle(holiday, year);
            return result;
        }

        public bool IsValidForCyle(Holiday holiday, int year)
        {
            int cycleYears;
            switch (holiday.every)
            {
                case HolidayCycleType.EVERY_YEAR:
                    return true;
                case HolidayCycleType.Item2_YEARS:
                    cycleYears = 2;
                    break;
                case HolidayCycleType.Item4_YEARS:
                    cycleYears = 4;
                    break;
                case HolidayCycleType.Item5_YEARS:
                    cycleYears = 5;
                    break;
                case HolidayCycleType.Item6_YEARS:
                    cycleYears = 6;
                    break;
                case HolidayCycleType.ODD_YEARS:
                    return year%2 != 0;
                case HolidayCycleType.EVEN_YEARS:
                    return year%2 == 0;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (holiday.validFrom == 0)
                return true;

            return (year - holiday.validFrom)%cycleYears == 0;
        }

        public DateTime? GetFixedHolidyDay(Fixed fixedHoliday, int year)
        {
            if (!IsValid(fixedHoliday, year))
                return null;

            return MoveDate(fixedHoliday, new DateTime(year, ConvertMonth(fixedHoliday.month), fixedHoliday.day));
        }

        public DateTime GetEasternSunday(ChronologyType chronology, int year)
        {
            switch (chronology)
            {
                case ChronologyType.JULIAN:
                    return year <= 1583 ? GetJulianEasternSunday(year) : GetGregorianEasterSunday(year);
                case ChronologyType.GREGORIAN:
                    return GetGregorianEasterSunday(year);
                default:
                    throw new ArgumentOutOfRangeException("chronology");
            }
        }

        public DateTime MoveDate(MoveableHoliday moveableHoliday, DateTime calculatedDateTime)
        {
            var currentCondition = moveableHoliday.MovingCondition.FirstOrDefault(a => MustMove(a, calculatedDateTime));
            while (currentCondition != null)
            {
                calculatedDateTime = MoveHoliday(currentCondition, calculatedDateTime);
                currentCondition = moveableHoliday.MovingCondition.FirstOrDefault(a => MustMove(a, calculatedDateTime));
            }
            return calculatedDateTime;

            
        }
        #endregion

        #region helper factory methods ----------------------------------------
        //private Calendar GetCalendarForChronology(ChronologyType chronologyType)
        //{
        //    switch (chronologyType)
        //    {
        //        case ChronologyType.JULIAN:
        //           return new GregorianCalendar();
        //        case ChronologyType.GREGORIAN:
        //            return new GregorianCalendar();
        //        default:
        //            throw new ArgumentOutOfRangeException("chronologyType");
        //    }
        //}
        #endregion

        #region helper methods ------------------------------------------------

        private DateTime MoveHoliday(MovingCondition movingCondition, DateTime dateTimeToMove)
        {
            var targetWeekday = ConvertWeekday(movingCondition.weekday);
            var direction = movingCondition.with == With.NEXT ? 1 : -1;

            while (dateTimeToMove.DayOfWeek != targetWeekday)
                dateTimeToMove = dateTimeToMove.AddDays(direction);

            return dateTimeToMove;
        }

        private bool MustMove(MovingCondition movingCondition, DateTime calculatedDateTime)
        {
            switch (movingCondition.substitute)
            {
                case Substituted.ON_SATURDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Saturday;
                case Substituted.ON_SUNDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Sunday;
                case Substituted.ON_WEEKEND:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Sunday ||
                           calculatedDateTime.DayOfWeek == DayOfWeek.Saturday;
                case Substituted.ON_MONDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Monday;
                case Substituted.ON_TUESDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Tuesday;
                case Substituted.ON_WEDNESDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Wednesday;
                case Substituted.ON_THURSDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Thursday;
                case Substituted.ON_FRIDAY:
                    return calculatedDateTime.DayOfWeek == DayOfWeek.Friday;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int ConvertMonth(Month month)
        {
            switch (month)
            {
                case Month.JANUARY:
                    return 1;
                case Month.FEBRUARY:
                    return 2;
                case Month.MARCH:
                    return 3;
                case Month.MAY:
                    return 5;
                case Month.JUNE:
                    return 6;
                case Month.JULY:
                    return 7;
                case Month.AUGUST:
                    return 8;
                case Month.SEPTEMBER:
                    return 9;
                case Month.OCTOBER:
                    return 10;
                case Month.NOVEMBER:
                    return 11;
                case Month.DECEMBER:
                    return 12;
                case Month.APRIL:
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException("month");
            }
        }

        private DayOfWeek ConvertWeekday(Weekday weekday)
        {
            switch (weekday)
            {
                case Weekday.MONDAY:
                    return DayOfWeek.Monday;
                case Weekday.TUESDAY:
                    return DayOfWeek.Tuesday;
                case Weekday.WEDNESDAY:
                    return DayOfWeek.Wednesday;
                case Weekday.THURSDAY:
                    return DayOfWeek.Thursday;
                case Weekday.FRIDAY:
                    return DayOfWeek.Friday;
                case Weekday.SATURDAY:
                    return DayOfWeek.Saturday;
                case Weekday.SUNDAY:
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentOutOfRangeException("weekday");
            }
        }
        private DateTime GetJulianEasternSunday(int year)
        {
            var a = year%4;
            var b = year%7;
            var century = year%19;
            var d = (19*century + 15)%30;
            var e = (2*a + 4*b - d + 34)%7;
            var x = d + e + 114;
            var month = x/31;
            var day = (x%31) + 1;
            return new DateTime(year, month == 3 ? 3 : 4, day);

        }

        public DateTime GetGregorianEasterSunday(int year)
        {
            var a = year%19;
            var b = year/100;
            var c = year%100;
            var d = b/4;
            var e = b%4;
            var f = (b + 8)/25;
            var g = (b - f + 1)/3;
            var h = (19*a + b - d - g + 15)%30;
            var i = c/4;
            var j = c%4;
            var k = (32 + 2*e + 2*i - h - j)%7;
            var l = (a + 11*h + 22*k)/451;
            var x = h + k - 7*l + 114;
            var month = x/31;
            var day = (x%31) + 1;
            return new DateTime(year, month == 3 ? 3 : 4, day);
        }

        #endregion
    }
}
