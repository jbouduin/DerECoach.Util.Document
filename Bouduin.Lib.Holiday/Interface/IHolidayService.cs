using System.Collections.Generic;

namespace Bouduin.Lib.Holidays.Interface
{

    public interface IHolidayService
    {
        IEnumerable<IHolidayDate> GetHolidayDates(string hierarchyPath, int year);
    }
}
