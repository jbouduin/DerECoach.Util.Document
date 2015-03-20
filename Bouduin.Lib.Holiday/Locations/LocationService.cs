using Bouduin.Lib.Holiday.Parsers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bouduin.Lib.Holiday.Locations
{

    internal interface ILocationService
    {
        IEnumerable<ILocation> GetSupportedLocations();
        void GetLocationDetails(ILocation location, bool deepLoad);
    }
    /// <summary>
    /// The location provider
    /// </summary>
    internal class LocationService: ILocationService
    {
        private readonly Dictionary<string, ILevel1Location> _level1Locations = new Dictionary<string, ILevel1Location>();

        #region constructor ---------------------------------------------------

        public LocationService()
        {
            LoadSupportedLocations();
        }

        private void LoadSupportedLocations()
        {
            var headerParser = new HeaderParser();
            Directory.GetFiles(@".\\Data", "*.xml").ToList().ForEach(dataFile =>
            {
                var level1Location = headerParser.GetLocation(dataFile);
                if (level1Location != null)
                    _level1Locations.Add(level1Location.Code, level1Location);
            });

        }
        #endregion

        #region ILocationService members --------------------------------------
        public IEnumerable<ILocation> GetSupportedLocations()
        {
            return _level1Locations.Values;
        }

        public void GetLocationDetails(ILocation location, bool deepLoad)
        {

        }
        #endregion


    }
}
