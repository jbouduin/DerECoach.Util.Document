using System.Collections.Generic;
using System.Globalization;

namespace Bouduin.Lib.Holidays.Interface
{

    public interface IHolidayService
    {
        IEnumerable<IHolidayDate> GetHolidayDates(string hierarchyPath, int year, CultureInfo cultureInfo);
    }
}
