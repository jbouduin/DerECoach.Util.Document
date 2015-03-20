using System.Collections.Generic;

namespace Bouduin.Lib.Holiday.Locations
{
    public interface ILocation
    {
        string Code { get; }
        string Description { get; }
        List<ILocation> Children { get; }
    }
}
