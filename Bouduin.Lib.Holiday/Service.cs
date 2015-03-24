using Bouduin.Lib.Holidays.Configurations;
using Bouduin.Lib.Holidays.Interface;
using Bouduin.Lib.Holidays.Locations;
using Bouduin.Lib.Holidays.Services;
using System.Collections.Generic;
using System.Globalization;

namespace Bouduin.Lib.Holidays
{
    public class Service
    {
        #region factory methods -----------------------------------------------
        public static IHolidayService GetHolidayService()
        {
            return new HolidayService(ConfigurationService, LocalizationService, ChristianHolidayService, CalendarService);
        }
        #endregion

        #region query methods -------------------------------------------------
        private static readonly ILocalizationService LocalizationService = new LocalizationService();
        private static readonly IConfigurationService ConfigurationService = new ConfigurationService(LocalizationService);
        private static readonly ICalendarService CalendarService = new CalendarService();
        private static readonly IChristianHolidayService ChristianHolidayService = new ChristianHolidayService(CalendarService);

        public static IEnumerable<ILocation> GetSupportedLocations(CultureInfo cultureInfo)
        {
            return ConfigurationService.GetSupportedLocations(cultureInfo);
        }
        public static IEnumerable<ILocation> GetSupportedLocations()
        {
            return ConfigurationService.GetSupportedLocations(CultureInfo.CurrentCulture);
        }

        #endregion
    }
}
