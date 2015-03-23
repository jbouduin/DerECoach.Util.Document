using System.Collections.Generic;

namespace Bouduin.Lib.Holiday.Locations
{
    public interface ILocation
    {
        string Path { get; }
        string Description { get; }
        List<ILocation> Children { get; }
    }
}
