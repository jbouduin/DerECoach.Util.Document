using System.Globalization;

namespace Bouduin.Util.Common.Extensions
{
    public static class IntExtensions
    {
        public static string ToInvariantString(this int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}