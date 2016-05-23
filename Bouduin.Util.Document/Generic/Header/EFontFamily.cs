using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Header
{
    /// <summary>
    /// Specifies font family.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum EFontFamily
    {
        [RtfControlWord("fnil")]
        Default,
        [RtfControlWord("froman")]
        Roman,
        [RtfControlWord("fswiss")]
        Swiss,
        [RtfControlWord("fmodern")]
        FixedPitch,
        [RtfControlWord("fscript")]
        Script,
        [RtfControlWord("fdecor")]
        Decorative,
        [RtfControlWord("ftech")]
        Technical,
        [RtfControlWord("fbidi")]
        Bidirectional
    }
}