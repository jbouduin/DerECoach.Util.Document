using System;
using System.Collections.Generic;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Common
{
    /// <summary>
    /// Converts twips to metric units, and metric units to twips
    /// </summary>
    internal class TwipConverter : ITwipConverter
    {
        #region fields --------------------------------------------------------
        private readonly float _pointsInTwip = .05F;
        private readonly float _millimetersInTwip = .0176389F;
        private readonly float _centimetersInTwip = .0017639F;
        private readonly float _inchsInTwip = 1F / 1440;

        private readonly float _twipsInPoint = 20;
        private readonly float _twipsInMillimeter = 56.6929134F;
        private readonly float _twipsInCentimeter = 566.9291339F;
        private readonly float _twipsInInch = 1440F;

        private readonly Dictionary<EMetricUnit, float> _toUnitConversion;

        private readonly Dictionary<EMetricUnit, float> _toTwipConversion;

        #endregion

        #region ITwipConverter members ----------------------------------------
        /// <summary>
        /// Converts metric values to twips
        /// </summary>
        /// <param name="value">Value in metric units</param>
        /// <param name="unit">Unit which is used to specify the value</param>
        /// <returns>Value in twips</returns>
        public int ToTwip(float value, EMetricUnit unit)
        {
            return (int) Math.Round(value*_toTwipConversion[unit]);
        }

        /// <summary>
        /// Converts twips to points
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in points</returns>
        public float ToPoint(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Point);
        }

        /// <summary>
        /// Converts twips to millimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in millimeters</returns>
        public float ToMillimeter(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Millimeter);
        }

        /// <summary>
        /// Converts twips to centimeters
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <returns>Value in centimeters</returns>
        public float ToCentimeter(int value)
        {
            return ToMetricUnit(value, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Converts twips to metric values
        /// </summary>
        /// <param name="value">Value in twips</param>
        /// <param name="unit">Metric unit to convert to</param>
        /// <returns>Value in specified metric units</returns>
        public float ToMetricUnit(int value, EMetricUnit unit)
        {
            return (float) Math.Round(value*_toUnitConversion[unit]);
        }

        public float PointsInTwip
        {
            get { return _pointsInTwip; }
        }

        public float MillimetersInTwip
        {
            get { return _millimetersInTwip; }
        }

        public float CentimetersInTwip
        {
            get { return _centimetersInTwip; }
        }

        public float InchsInTwip
        {
            get { return _inchsInTwip; }
        }

        public float TwipsInPoint
        {
            get { return _twipsInPoint; }
        }

        public float TwipsInMillimeter
        {
            get { return _twipsInMillimeter; }
        }

        public float TwipsInCentimeter
        {
            get { return _twipsInCentimeter; }
        }

        public float TwipsInInch
        {
            get { return _twipsInInch; }
        }
        #endregion

        #region constructor ---------------------------------------------------

        public TwipConverter()
        {
            _toUnitConversion = new Dictionary<EMetricUnit, float>
            {
                {EMetricUnit.Point, PointsInTwip},
                {EMetricUnit.Millimeter, MillimetersInTwip},
                {EMetricUnit.Centimeter, CentimetersInTwip},
                {EMetricUnit.Inch, InchsInTwip}
            };

            _toTwipConversion = new Dictionary<EMetricUnit, float>()
            {
                {EMetricUnit.Point, TwipsInPoint},
                {EMetricUnit.Millimeter, TwipsInMillimeter},
                {EMetricUnit.Centimeter, TwipsInCentimeter},
                {EMetricUnit.Inch, TwipsInInch}
            };
        }
        #endregion
    }
}