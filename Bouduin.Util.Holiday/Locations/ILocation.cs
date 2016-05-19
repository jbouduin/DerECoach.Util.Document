using System.Collections.Generic;

namespace Bouduin.Util.Holiday.Locations
{
    public interface ILocation
    {
        // TODO Flag { get; }
        string Path { get; }
        string Description { get; }
        List<ILocation> Children { get; }
    }
}
