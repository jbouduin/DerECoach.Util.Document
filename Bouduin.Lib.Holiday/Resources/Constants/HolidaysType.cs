
using System;

namespace Bouduin.Lib.Holiday.Resources.Constants
{
    internal enum HolidayType
    {
        Fixed,
        RelativeToFixed,
        RelativeToWeekdayInMonth,
        FixedWeekday,
        ChristianHoliday,
        IslamicHoliday,
        FixedWeekdayBetweenFixed,
        FixedWeekdayRelativeToFixed,
        HinduHoliday,
        HebrewHoliday,
        EthiopianOrthodoxHoliday,
        RelativeToEasterSunday
    }

    internal class HolidaysTypeUtility
    {
        private const string HolidayTypeFixed = "Fixed";
        private const string HolidayTypeRelativeToFixed = "RelativeToFixed";
        private const string HolidayTypeRelativeToWeekdayInMonth = "RelativeToWeekdayInMonth";
        private const string HolidayTypeFixedWeekday = "FixedWeekday";
        private const string HolidayTypeChristianHoliday = "ChristianHoliday";
        private const string HolidayTypeIslamicHoliday = "IslamicHoliday";
        private const string HolidayTypeFixedWeekdayBetweenFixed = "FixedWeekdayBetweenFixed";
        private const string HolidayTypeFixedWeekdayRelativeToFixed = "FixedWeekdayRelativeToFixed";
        private const string HolidayTypeHinduHoliday = "HinduHoliday";
        private const string HolidayTypeHebrewHoliday = "HebrewHoliday";
        private const string HolidayTypeEthiopianOrthodoxHoliday = "EthiopianOrthodoxHoliday";
        private const string HolidayTypeRelativeToEasterSunday = "RelativeToEasterSunday";

        internal static string HolidayTypeToDisplayString(HolidayType holidayType)
        {
            switch (holidayType)
            {
                case HolidayType.Fixed:
                    return "Fixed";
                case HolidayType.RelativeToFixed:
                    return "Relativet to fixed";
                case HolidayType.RelativeToWeekdayInMonth:
                    return "Relative to weekday in month";
                case HolidayType.FixedWeekday:
                    return "Fixed weekday";
                case HolidayType.ChristianHoliday:
                    return "Christian holiday";
                case HolidayType.IslamicHoliday:
                    return "Islamic holiday";
                case HolidayType.FixedWeekdayBetweenFixed:
                    return "Fixed weekday between fixed";
                case HolidayType.FixedWeekdayRelativeToFixed:
                    return "Fixed weekday relative to fixed";
                case HolidayType.HinduHoliday:
                    return "Hindu holiday";
                case HolidayType.HebrewHoliday:
                    return "Hebrew holiday";
                case HolidayType.EthiopianOrthodoxHoliday:
                    return "Ethiopian Orthodox holiday";
                case HolidayType.RelativeToEasterSunday:
                    return "Relative to Easter Sunday";
                default:
                    throw new ArgumentOutOfRangeException("holidayType");
            }
        }

        internal static string HolidayTypeToString(HolidayType holidayType)
        {
            switch (holidayType)
            {
                case HolidayType.Fixed:
                    return @"Fixed";
                case HolidayType.RelativeToFixed:
                    return @"RelativeToFixed";
                case HolidayType.RelativeToWeekdayInMonth:
                    return @"RelativeToWeekdayInMonth";
                case HolidayType.FixedWeekday:
                    return @"FixedWeekday";
                case HolidayType.ChristianHoliday:
                    return @"ChristianHoliday";
                case HolidayType.IslamicHoliday:
                    return @"IslamicHoliday";
                case HolidayType.FixedWeekdayBetweenFixed:
                    return @"FixedWeekdayBetweenFixed";
                case HolidayType.FixedWeekdayRelativeToFixed:
                    return @"FixedWeekdayRelativeToFixed";
                case HolidayType.HinduHoliday:
                    return @"HinduHoliday";
                case HolidayType.HebrewHoliday:
                    return @"HebrewHoliday";
                case HolidayType.EthiopianOrthodoxHoliday:
                    return @"EthiopianOrthodoxHoliday";
                case HolidayType.RelativeToEasterSunday:
                    return @"RelativeToEasterSunday";
                default:
                    throw new ArgumentOutOfRangeException("holidayType");
            }
        }

        internal static HolidayType HoliFromString(string holidayTypeString)
        {
            switch (holidayTypeString)
            {
                case HolidayTypeFixed:
                    return HolidayType.Fixed;
                case HolidayTypeRelativeToFixed:
                    return HolidayType.RelativeToFixed;
                case HolidayTypeRelativeToWeekdayInMonth:
                    return HolidayType.RelativeToWeekdayInMonth;
                case HolidayTypeFixedWeekday:
                    return HolidayType.FixedWeekday;
                case HolidayTypeChristianHoliday:
                    return HolidayType.ChristianHoliday;
                case HolidayTypeIslamicHoliday:
                    return HolidayType.IslamicHoliday;
                case HolidayTypeFixedWeekdayBetweenFixed:
                    return HolidayType.FixedWeekdayBetweenFixed;
                case HolidayTypeFixedWeekdayRelativeToFixed:
                    return HolidayType.FixedWeekdayRelativeToFixed;
                case HolidayTypeHinduHoliday:
                    return HolidayType.HinduHoliday;
                case HolidayTypeHebrewHoliday:
                    return HolidayType.HebrewHoliday;
                case HolidayTypeEthiopianOrthodoxHoliday:
                    return HolidayType.EthiopianOrthodoxHoliday;
                case HolidayTypeRelativeToEasterSunday:
                    return HolidayType.RelativeToEasterSunday;
                default:
                    throw new ArgumentOutOfRangeException("holidayTypeString");
            }
        }
    }
}
