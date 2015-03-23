using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bouduin.Lib.Holidays.Locations;

namespace Bouduin.Lib.Holidays.Configurations
{

    internal interface IConfigurationService
    {
        IEnumerable<ILocation> GetSupportedLocations();
        Dictionary<string,Holidays> GetHolidays(string hierarchyPath);

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

        public Dictionary<string,Holidays> GetHolidays(string hierarchyPath)
        {
            var splittedPath = hierarchyPath.Split(new[] {'/'});
            var result = new Dictionary<string, Holidays>();
            if (splittedPath.Length == 0)
                throw new ArgumentException("hierarchyPath");

            var configuration = _configurations[splittedPath[0]];
            result.Add(splittedPath[0], configuration.Holidays);

            for (var i = 1; i < splittedPath.Length; i++)
            {
                configuration = configuration[splittedPath[i]];
                result.Add(splittedPath[i], configuration.Holidays);
            }

            return result;
        }

        #endregion

        #region helper methods ------------------------------------------------
        private void ProcessHierarchy(Location location, Configuration configuration)
        {
            configuration.SubConfigurations.ForEach(sub =>
            {
                var subLocation = location.AddChild(sub.hierarchy, sub.description);
                ProcessHierarchy(subLocation, sub);
            });
        }
        #endregion


    }
}
