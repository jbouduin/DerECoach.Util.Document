using System.Globalization;

namespace Bouduin.Lib.Holidays.Services
{
    internal interface ILocalizationService
    {
        string GetHierarchyDescription(string descriptionKey, string defaultValue);
        string GetHolidayDescription(string descriptionKey);
        string GetChristianHolidayDescription(string descriptionKey);
        string GetEthiopianOrthodoxHolidayDescription(string descriptionKey);
        string GetIslamicHolidayDescription(string descriptionKey);
        void SetCurrentCulture(CultureInfo cultureInfo);
    }
}