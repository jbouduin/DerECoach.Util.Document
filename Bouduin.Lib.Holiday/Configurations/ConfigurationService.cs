using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bouduin.Lib.Holiday.Locations;

namespace Bouduin.Lib.Holiday.Configurations
{

    internal interface IConfigurationService
    {
        IEnumerable<ILocation> GetSupportedLocations();
        void GetLocationDetails(ILocation location, bool deepLoad);
    }
    /// <summary>
    /// The location provider
    /// </summary>
    internal class ConfigurationService: IConfigurationService
    {
        private readonly Dictionary<string, Configuration> _configurations = new Dictionary<string, Configuration>(); 
        #region constructor ---------------------------------------------------

        public ConfigurationService()
        {
            LoadHierarchies();
        }

        private void LoadHierarchies()
        {
            Directory.GetFiles(@".\\Data", "*.xml").ToList().ForEach(dataFile =>
            {
                try
                {
                    var configuration = Configuration.LoadFromFile(dataFile);
                    _configurations.Add(configuration.hierarchy, configuration);
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch (Exception)
                {
                    // do nothing, the file is invalid anyway
                }
                // ReSharper restore EmptyGeneralCatchClause
            });

        }


        #endregion

        #region ILocationService members --------------------------------------
        public IEnumerable<ILocation> GetSupportedLocations()
        {
            var supportedLocations =  _configurations.Values.Select(configuration =>
            {
                // TODO localization
                var result = Location.CreateRootLocation(configuration.hierarchy, configuration.description);
                ProcessHierarchy(result, configuration);
                return result;
            });
            return supportedLocations;
        }

        private void ProcessHierarchy(Location location, Configuration configuration)
        {
            configuration.SubConfigurations.ForEach(sub =>
            {
                var subLocation = location.AddChild(sub.hierarchy, sub.description);
                ProcessHierarchy(subLocation, sub);
            });
        }
        public void GetLocationDetails(ILocation location, bool deepLoad)
        {

        }
        #endregion


    }
}
