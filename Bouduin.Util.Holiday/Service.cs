using System.Collections.Generic;
using System.Globalization;
using Bouduin.Util.Holiday.Configurations;
using Bouduin.Util.Holiday.Interface;
using Bouduin.Util.Holiday.Locations;
using Bouduin.Util.Holiday.Services;

namespace Bouduin.Util.Holiday
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

        /// <summary>
        /// Get a collection of Supported Locations, including there sub-locations
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static IEnumerable<ILocation> GetSupportedLocations(CultureInfo cultureInfo)
        {
            return ConfigurationService.GetSupportedLocations(cultureInfo);
        }

        /// <summary>
        /// Get a collection of Supported Locations, including there sub-locations
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ILocation> GetSupportedLocations()
        {
            return ConfigurationService.GetSupportedLocations(CultureInfo.CurrentCulture);
        }

        #endregion
    }
}
