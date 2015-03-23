using System;
using Bouduin.Lib.Holidays.Configurations;

namespace Bouduin.Lib.Holidays.Services
{

    internal class ChristianHolidayService: IChristianHolidayService
    {
        #region fields --------------------------------------------------------

        private readonly ICalendarService _calendarService;

        #endregion

        #region constructor ---------------------------------------------------

        internal ChristianHolidayService(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        #endregion

        #region IChristianHolidayService members ------------------------------

        public DateTime? GetChristianHoliday(ChristianHoliday christianHoliday, int year)
        {
            if (!_calendarService.IsValid(christianHoliday, year))
                return null;

            var easternSunday = _calendarService.GetEasternSunday(christianHoliday.chronology, year);
            
            switch (christianHoliday.type)
            {
                case ChristianHolidayType.GOOD_FRIDAY:
                    return easternSunday.AddDays(-2);
                case ChristianHolidayType.EASTER_MONDAY:
                    return easternSunday.AddDays(1);
                case ChristianHolidayType.ASCENSION_DAY:
                    return easternSunday.AddDays(39);
                case ChristianHolidayType.WHIT_MONDAY:
                case ChristianHolidayType.PENTECOST_MONDAY:
                    return easternSunday.AddDays(50);
                case ChristianHolidayType.CORPUS_CHRISTI:
                    return easternSunday.AddDays(60);
                case ChristianHolidayType.MAUNDY_THURSDAY:
                    return easternSunday.AddDays(-3);
                case ChristianHolidayType.ASH_WEDNESDAY:
                    return easternSunday.AddDays(-46);
                case ChristianHolidayType.GENERAL_PRAYER_DAY:
                    return easternSunday.AddDays(26);
                case ChristianHolidayType.CLEAN_MONDAY:
                case ChristianHolidayType.SHROVE_MONDAY:
                    return easternSunday.AddDays(-48);
                case ChristianHolidayType.WHIT_SUNDAY:
                case ChristianHolidayType.PENTECOST:
                    return easternSunday.AddDays(49);
                case ChristianHolidayType.MARDI_GRAS:
                case ChristianHolidayType.CARNIVAL:
                    return easternSunday.AddDays(-47);
                case ChristianHolidayType.EASTER_SATURDAY:
                    return easternSunday.AddDays(-1);
                case ChristianHolidayType.EASTER_TUESDAY:
                    return easternSunday.AddDays(2);
                case ChristianHolidayType.SACRED_HEART:
                    return easternSunday.AddDays(68);
                case ChristianHolidayType.EASTER:
                    return easternSunday;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
        

        
    }
}
