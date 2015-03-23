
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Bouduin.Holiday.ViewModels.HolidayGrid;
using Bouduin.Holiday.Views;
using Bouduin.Lib.Holidays;
using Bouduin.Lib.Holidays.Locations;

namespace Bouduin.Holiday.ViewModels.LocationTree
{
    internal interface ILocationTreeViewModel
    {
        List<ILocationTreeViewItemViewModel> Locations { get; }
    }

    internal class LocationTreeViewModel: ILocationTreeViewModel
    {
        #region fields --------------------------------------------------------
        private IHolidayGridViewModel _holidayGridViewModel;
        #endregion

        #region ILocationTreeViewModel members --------------------------------

        public List<ILocationTreeViewItemViewModel> Locations { get; private set; }

        #endregion

        #region constructor ---------------------------------------------------

        public LocationTreeViewModel(IHolidayGridViewModel holidayGridViewModel)
        {
            _holidayGridViewModel = holidayGridViewModel;
            var locations = Service.GetSupportedLocations();
            Locations = new List<ILocationTreeViewItemViewModel>();
            locations.OrderBy(ob => ob.Description).ToList().ForEach(AddRootLocation);
        }
        #endregion

        #region fill model ----------------------------------------------------

        private void AddRootLocation(ILocation location)
        {
            var newLocation = new LocationTreeViewItemViewModel(_holidayGridViewModel, location);
            Locations.Add(newLocation);
            
        }
        #endregion
    }
}
