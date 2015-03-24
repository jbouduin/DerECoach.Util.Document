using Bouduin.Lib.Holidays.Configurations;
using Bouduin.Lib.Holidays.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Bouduin.Lib.Holidays.Services
{
    internal class HolidayService: IHolidayService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IChristianHolidayService _christianHolidayService;
        private readonly ICalendarService _calendarService;

        #region constructors --------------------------------------------------
        public HolidayService(IConfigurationService configurationService, IChristianHolidayService christianHolidayService, ICalendarService calendarService)
        {
            _configurationService = configurationService;
            _christianHolidayService = christianHolidayService;
            _calendarService = calendarService;
        }

        #endregion

        #region IHolidayService members ---------------------------------------

        public IEnumerable<IHolidayDate> GetHolidayDates(string hierarchyPath, int year)
        {
            var definitions = _configurationService.GetHolidays(hierarchyPath);
            
            var result = new List<IHolidayDate>();
            definitions.ToList().ForEach(fe => result.AddRange(ProcessHolidays(fe.Key, fe.Value, year)));
            return result;
        }
        

        #endregion

        #region helper methods ------------------------------------------------

        private IEnumerable<IHolidayDate> ProcessHolidays(string path, Configurations.Holidays holidays, int year)
        {
            var result = new List<IHolidayDate>();
            holidays.ChristianHoliday.ForEach(fe =>
            {
                var date = _christianHolidayService.GetChristianHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.type.ToString()));
            });

            // TODO
            holidays.EthiopianOrthodoxHoliday.ForEach(fe =>
            {
                    
            });

            holidays.Fixed.ForEach(fe =>
            {
                var date = _calendarService.GetFixedHolidyday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path,path, fe.descriptionPropertiesKey));
            });

            holidays.FixedWeekday.ForEach(fe =>
            {
                var date = _calendarService.GetFixedWeekdayInMonthHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });

            holidays.FixedWeekdayBetweenFixed.ForEach(fe =>
            {
                var date = _calendarService.GetFixedWeekdayBetweenFixedHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });

            holidays.FixedWeekdayRelativeToFixed.ForEach(fe =>
            {
                var date = _calendarService.GetFixedWeekdayRelativeToFixedHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });

            // TODO
            holidays.HebrewHoliday.ForEach(fe =>
            {
                
            });

            holidays.HinduHoliday.ForEach(fe =>
            {
                
            });

            holidays.IslamicHoliday.ForEach(fe =>
            {
                
            });

            holidays.RelativeToEasterSunday.ForEach(fe =>
            {
                var date = _calendarService.GetRelativeToEasterSundayHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });

            holidays.RelativeToFixed.ForEach(fe =>
            {
                var date = _calendarService.GetRelativeToFixedHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });

            holidays.RelativeToWeekdayInMonth.ForEach(fe =>
            {
                var date = _calendarService.GetRelativeToWeekdayInMonthHoliday(fe, year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.descriptionPropertiesKey));
            });
            return result;
        }

        #endregion

    }
}
