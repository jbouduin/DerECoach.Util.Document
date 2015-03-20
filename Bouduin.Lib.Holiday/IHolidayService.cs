using Bouduin.Lib.Holiday.Locations;
using System.Collections.Generic;

namespace Bouduin.Lib.Holiday
{

    public interface IHolidayService
    {
        List<ILocation> GetSupportedLocations();
    }
}
