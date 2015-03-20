using Bouduin.Lib.Holiday.Locations;
using System.Collections.Generic;
using System.Globalization;

namespace Bouduin.Lib.Holiday
{
    public class Service
    {
        #region factory methods -----------------------------------------------
        public static IHolidayService GetHolidayService()
        {
            return new HolidayService(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

        public static IHolidayService GetHolidayService(string location)
        {
            return new HolidayService(location);
        }

        public static IHolidayService GetHolidayService(string location, params string[] hierarchy)
        {
            return new HolidayService(location, hierarchy);
        }
        #endregion

        #region query methods -------------------------------------------------
        private static readonly ILocationService LocationService = new LocationService();
        public static IEnumerable<ILocation> GetSupportedLocations()
        {
            return LocationService.GetSupportedLocations();
        }

        #endregion
    }
}
