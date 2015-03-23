using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bouduin.Lib.Holiday.Resources.Constants
{
    internal enum HolidayCycleType
    {
        EveryYear,
        TwoYears,
        FourYears,
        FiveYears,
        SixYears,
        OddYears,
        EvenYears
    }

    internal class HolidayCycleTypeUtility
    {
        private const string HolidayCycleTypeEveryYear = "EVERY_YEAR";
        private const string HolidayCycleTypeTwoYears = "2_YEARS";
        private const string HolidayCycleTypeFourYears = "4_YEARS";
        private const string HolidayCycleTypeFiveYears = "5_YEARS";
        private const string HolidayCycleTypeSixYears = "6_YEARS";
        private const string HolidayCycleTypeOddYears = "ODD_YEARS";
        private const string HolidayCycleTypeEvenYears = "EVEN_YEARS";

        internal static string HolidayCycleTypeToDisplayString(HolidayCycleType holidayCycleType)
        {
            switch (holidayCycleType)
            {
                case HolidayCycleType.EveryYear:
                    return "Every year";
                case HolidayCycleType.TwoYears:
                    return "Every second year";
                case HolidayCycleType.FourYears:
                    return "Every fourth year";
                case HolidayCycleType.FiveYears:
                    return "Every fifth year";
                case HolidayCycleType.SixYears:
                    return "Every sixt year";
                case HolidayCycleType.OddYears:
                    return "Odd years";
                case HolidayCycleType.EvenYears:
                    return "Even years";
                default:
                    throw new ArgumentOutOfRangeException("holidayCycleType");
            }
        }

        internal static string HolidayCycleTypeToString(HolidayCycleType holidayCycleType)
        {
            switch (holidayCycleType)
            {
                case HolidayCycleType.EveryYear:
                    return HolidayCycleTypeEveryYear;
                case HolidayCycleType.TwoYears:
                    return HolidayCycleTypeTwoYears;
                case HolidayCycleType.FourYears:
                    return HolidayCycleTypeFourYears;
                case HolidayCycleType.FiveYears:
                    return HolidayCycleTypeFiveYears ;
                case HolidayCycleType.SixYears:
                    return HolidayCycleTypeSixYears;
                case HolidayCycleType.OddYears:
                    return HolidayCycleTypeOddYears;
                case HolidayCycleType.EvenYears:
                    return HolidayCycleTypeEvenYears;
                default:
                    throw new ArgumentOutOfRangeException("holidayCycleType");
            }
        }

        internal static string HolidayCycleTypeFromString(HolidayCycleType holidayCycleType)
        {
            switch (holidayCycleType)
            {
                case HolidayCycleType.EveryYear:
                    return HolidayCycleTypeEveryYear;
                case HolidayCycleType.TwoYears:
                    return HolidayCycleTypeTwoYears;
                case HolidayCycleType.FourYears:
                    return HolidayCycleTypeFourYears;
                case HolidayCycleType.FiveYears:
                    return HolidayCycleTypeFiveYears;
                case HolidayCycleType.SixYears:
                    return HolidayCycleTypeSixYears;
                case HolidayCycleType.OddYears:
                    return HolidayCycleTypeOddYears;
                case HolidayCycleType.EvenYears:
                    return HolidayCycleTypeEvenYears;
                default:
                    throw new ArgumentOutOfRangeException("holidayCycleType");
            }
        }
    }

}
