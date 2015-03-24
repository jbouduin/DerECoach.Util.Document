using System.Collections.Generic;

namespace Bouduin.Lib.Holidays.Locations
{
    public interface ILocation
    {
        //TODO Flag { get; }
        string Path { get; }
        string Description { get; }
        List<ILocation> Children { get; }
    }
}
