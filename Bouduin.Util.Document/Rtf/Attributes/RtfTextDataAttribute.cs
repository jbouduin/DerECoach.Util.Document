using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    internal enum RtfTextDataType { Text, HyperLink, Raw }
    
    /// <summary>
    /// Specifies text data.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfTextDataAttribute : Attribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets or sets a Boolean value indicating whether RtfWriter should enclose text with quotes.
        /// </summary>
        public bool Quotes { get; set; }

        /// <summary>
        /// Gets text data type.
        /// </summary>
        public RtfTextDataType TextDataType { get; private set; }
        #endregion

        #region constructor ---------------------------------------------------
        internal RtfTextDataAttribute()
        {
            TextDataType = RtfTextDataType.Text;
        }

        internal RtfTextDataAttribute(RtfTextDataType type)
        {
            TextDataType = type;
        }
        #endregion
    }
}