using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Common
{
    public interface ITwipConverter
    {
        /// <summary>
        /// Converts metric values to twips
        /// </summary>
        /// <param name="value">Value in metric units</param>
        /// <param name="unit">Unit which is used to specify the value</param>
        /// <returns>Value in twips</returns>
        int ToTwip(float value, EMetricUnit unit);

        /// <summary>
        /// Converts twips to points
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in points</returns>
        float ToPoint(int value);

        /// <summary>
        /// Converts twips to millimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in millimeters</returns>
        float ToMillimeter(int value);

        /// <summary>
        /// Converts twips to centimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in centimeters</returns>
        float ToCentimeter(int value);

        /// <summary>
        /// Converts twips to metric values
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <param name="unit">Metric unit to convert to</param>
        /// <returns>Value in specified metric units</returns>
        float ToMetricUnit(int value, EMetricUnit unit);

        float PointsInTwip { get; }
        float MillimetersInTwip { get; }
        float CentimetersInTwip { get; }
        float InchsInTwip { get; }
        float TwipsInPoint { get; }
        float TwipsInMillimeter { get; }
        float TwipsInCentimeter { get; }
        float TwipsInInch { get; }
    }
}