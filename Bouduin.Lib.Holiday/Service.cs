using System.Collections.Generic;
using System.Globalization;
using Bouduin.Lib.Holidays.Configurations;
using Bouduin.Lib.Holidays.Interface;
using Bouduin.Lib.Holidays.Locations;
using Bouduin.Lib.Holidays.Services;

namespace Bouduin.Lib.Holidays
{
    public class Service
    {
        #region factory methods -----------------------------------------------
        public static IHolidayService GetHolidayService()
        {
            return new HolidayService(ConfigurationService, ChristianHolidayService, CalendarService);
        }
        #endregion

        #region query methods -------------------------------------------------
        private static readonly IConfigurationService ConfigurationService = new ConfigurationService();
        private static readonly ICalendarService CalendarService = new CalendarService();
        private static readonly IChristianHolidayService ChristianHolidayService = new ChristianHolidayService(CalendarService);


        public static IEnumerable<ILocation> GetSupportedLocations()
        {
            return ConfigurationService.GetSupportedLocations();
        }

        #endregion
    }
}
