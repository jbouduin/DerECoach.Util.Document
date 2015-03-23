using System;
using Bouduin.Lib.Holidays.Configurations;

namespace Bouduin.Lib.Holidays.Services
{
    interface ICalendarService
    {
        /// <summary>
        /// Checks the validity for the holiday, using the validfrom and validto years
        /// and the cycling property
        /// </summary>
        /// <param name="holiday"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        bool IsValid(Holiday holiday, int year);

        /// <summary>
        /// get the date for the fixed holiday in the given year
        /// </summary>
        /// <param name="fixedHoliday"></param>
        /// <param name="year"></param>
        /// <returns>the Date (Local time) if the holiday occurs in the given year</returns>
        DateTime? GetFixedHolidyDay(Fixed fixedHoliday, int year);

        /// <summary>
        /// Get eastern sunday for the given year
        /// </summary>
        /// <param name="chronology"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        DateTime GetEasternSunday(ChronologyType chronology, int year);


        DateTime MoveDate(MoveableHoliday moveableHoliday, DateTime calculatedDateTime);
    }
}
