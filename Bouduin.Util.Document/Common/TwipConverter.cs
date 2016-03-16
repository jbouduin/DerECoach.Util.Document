using System;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Common
{
    // TODO remove static stuff

    /// <summary>
    /// Converts twips to metric units, and metric units to twips
    /// </summary>
    public class TwipConverter
    {
        public const float PointsInTwip = .05F;
        public const float MillimetersInTwip = .0176389F;
        public const float CentimetersInTwip = .0017639F;
        public const float InchsInTwip = 1F/1440;

        public const float TwipsInPoint = 20;
        public const float TwipsInMillimeter = 56.6929134F;
        public const float TwipsInCentimeter = 566.9291339F;
        public const float TwipsInInch = 1440F;

        private static readonly float[]
            ToUnitConversion = {
                PointsInTwip,
                MillimetersInTwip,
                CentimetersInTwip,
                InchsInTwip,
            };

        private static readonly float[]
            ToTwipConversion = {
                TwipsInPoint,
                TwipsInMillimeter,
                TwipsInCentimeter,
                TwipsInInch,
            };

        /// <summary>
        /// Converts metric values to twips
        /// </summary>
        /// <param name="value">Value in metric units</param>
        /// <param name="unit">Unit which is used to specify the value</param>
        /// <returns>Value in twips</returns>
        public static int ToTwip(float value, EMetricUnit unit)
        {   
            return (int)Math.Round(value * ToTwipConversion[(int)unit]);
        }

        /// <summary>
        /// Converts twips to points
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in points</returns>
        public static float ToPoint(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Point);
        }

        /// <summary>
        /// Converts twips to millimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in millimeters</returns>
        public static float ToMillimeter(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Millimeter);
        }

        /// <summary>
        /// Converts twips to centimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in centimeters</returns>
        public static float ToCentimeter(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Converts twips to metric values
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <param name="unit">Metric unit to convert to</param>
        /// <returns>Value in specified metric units</returns>
        public static float ToMetricUnit(int value, EMetricUnit unit)
        {
            return (float)Math.Round(value * ToUnitConversion[(int)unit]);
        }
    }
}