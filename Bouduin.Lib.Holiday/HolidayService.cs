using Bouduin.Lib.Holiday.Locations;
using System;
using System.Collections.Generic;

namespace Bouduin.Lib.Holiday
{
    internal class HolidayService: IHolidayService
    {
        private string _location;
        private string[] _hierarchy;
        #region constructors --------------------------------------------------
        public HolidayService(string location)
        {
            _location = location;
        }

        public HolidayService(string location, params string[] hierarchy)
        {
            _location = location;
            _hierarchy = hierarchy;
        }
        #endregion

        #region IHolidayService members ---------------------------------------

        public List<ILocation> GetSupportedLocations()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
