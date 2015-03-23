using System;
using Bouduin.Lib.Holidays.Configurations;

namespace Bouduin.Lib.Holidays.Services
{
    internal interface IChristianHolidayService
    {
        DateTime? GetChristianHoliday(ChristianHoliday christianHoliday, int year);
    }
}
