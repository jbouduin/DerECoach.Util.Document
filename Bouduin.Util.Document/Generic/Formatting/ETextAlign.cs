using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Specifies text align inside a paragraph.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETextAlign
    {
        [RtfControlWord("ql")]
        Left,
        [RtfControlWord("qc")]
        Center,
        [RtfControlWord("qr")]
        Right,
        [RtfControlWord("qj")]
        Justified,
    }
}