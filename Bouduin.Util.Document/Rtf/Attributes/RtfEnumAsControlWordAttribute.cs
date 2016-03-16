using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    internal enum RtfEnumConversion { UseName, UseValue, UseAttribute }

    /// <summary>
    /// Specifies a way to convert an enum to a control word.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    internal class RtfEnumAsControlWordAttribute : Attribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets conversion type.
        /// </summary>
        internal RtfEnumConversion Conversion { get; private set; }
        
        /// <summary>
        /// Gets or sets a String value used as a prefix when converting an enum to control word.
        /// </summary>
        public string Prefix { get; set; }
        #endregion


        #region constructor ---------------------------------------------------
        internal RtfEnumAsControlWordAttribute(RtfEnumConversion conversion)
        {
            Conversion = conversion;
            Prefix = string.Empty;
        }
        #endregion

    }
}