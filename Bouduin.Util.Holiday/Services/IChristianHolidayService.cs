using System;
using Bouduin.Util.Holiday.Configurations;

namespace Bouduin.Util.Holiday.Services
{
    internal interface IChristianHolidayService
    {
        DateTime? GetChristianHoliday(ChristianHoliday christianHoliday, int year);
    }
}
