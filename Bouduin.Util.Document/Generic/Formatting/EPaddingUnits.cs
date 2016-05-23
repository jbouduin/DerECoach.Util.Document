using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Defines units used to specify padding.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseValue)]
    public enum EPaddingUnits
    {
        /// <summary>
        /// The reader should ignore padding.
        /// </summary>
        Null = 0,
        /// <summary>
        /// The padding is set in twips.
        /// </summary>
        Twips = 3
    }
}