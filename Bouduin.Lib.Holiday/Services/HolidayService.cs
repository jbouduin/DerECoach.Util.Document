using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bouduin.Lib.Holidays.Configurations;
using Bouduin.Lib.Holidays.Interface;

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

        public IEnumerable<IHolidayDate> GetHolidayDates(string hierarchyPath)
        {
            var definitions = _configurationService.GetHolidays(hierarchyPath);
            
            var result = new List<IHolidayDate>();
            definitions.ToList().ForEach(fe => result.AddRange(ProcessHolidays(fe.Key, fe.Value)));
            return result;
        }
        

        #endregion

        #region helper methods ------------------------------------------------

        private IEnumerable<IHolidayDate> ProcessHolidays(string path, Configurations.Holidays holidays)
        {
            var result = new List<IHolidayDate>();
            holidays.ChristianHoliday.ForEach(fe =>
            {
                var date = _christianHolidayService.GetChristianHoliday(fe, DateTime.Now.Year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path, path, fe.type.ToString()));
            });

            holidays.Fixed.ForEach(fe =>
            {
                var date = _calendarService.GetFixedHolidyDay(fe, DateTime.Now.Year);
                if (date.HasValue)
                    result.Add(new HolidayDate(date.Value, path,path, fe.descriptionPropertiesKey));
            });
            return result;
        }

        #endregion

    }
}
