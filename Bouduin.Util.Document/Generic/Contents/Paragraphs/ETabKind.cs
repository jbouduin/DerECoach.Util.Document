using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETabKind
    {
        Normal,
        [RtfControlWord("tqr")]
        FlushRight,
        [RtfControlWord("tqc")]
        Centered,
        [RtfControlWord("tqdec")]
        Decimal
    }
}