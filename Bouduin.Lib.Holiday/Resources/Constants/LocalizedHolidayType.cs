using System;

namespace Bouduin.Lib.Holiday.Resources.Constants
{
    internal enum LocalizedHolidayType
    {
        OfficialHoliday,
        UnofficialHoliday
    }

    internal class LocalizedHolidayTypeUtility
    {
        private const string LocalizedHolidayTypeOfficialHoliday = "OFFICIAL_HOLIDAY";
        private const string LocalizedHolidayTypeUnofficialHoliday = "UNOFFICIAL_HOLIDAY";

        internal static string LocalizedHolidayTypeToDisplayString(LocalizedHolidayType localizedHolidayType)
        {
            switch (localizedHolidayType)
            {
                case LocalizedHolidayType.OfficialHoliday:
                    return "Official holiday";
                case LocalizedHolidayType.UnofficialHoliday:
                    return "Unofficial holiday";
                default:
                    throw new ArgumentOutOfRangeException("localizedHolidayType");
            }
        }

        internal static string LocalizedHolidayTypeToString(LocalizedHolidayType localizedHolidayType)
        {
            switch (localizedHolidayType)
            {
                case LocalizedHolidayType.OfficialHoliday:
                    return LocalizedHolidayTypeOfficialHoliday;
                case LocalizedHolidayType.UnofficialHoliday:
                    return LocalizedHolidayTypeUnofficialHoliday;
                default:
                    throw new ArgumentOutOfRangeException("localizedHolidayType");
            }
        }

        internal static LocalizedHolidayType LocalizedHolidayTypeFromString(string localizedHolidayTypeString)
        {
            switch (localizedHolidayTypeString)
            {
                case LocalizedHolidayTypeOfficialHoliday:
                    return LocalizedHolidayType.OfficialHoliday;
                case LocalizedHolidayTypeUnofficialHoliday:
                    return LocalizedHolidayType.UnofficialHoliday;
                default:
                    throw new ArgumentOutOfRangeException("localizedHolidayTypeString");
            }
        }
        
    }
}
