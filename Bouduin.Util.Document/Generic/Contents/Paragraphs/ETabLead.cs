using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETabLead
    {
        None,
        [RtfControlWord("tldot")]
        Dots,
        [RtfControlWord("tlmdot")]
        MiddleDots,
        [RtfControlWord("tlhyph")]
        Hyphens,
        [RtfControlWord("tlul")]
        Underline,
        [RtfControlWord("tlth")]
        ThickLine,
        [RtfControlWord("tleq")]
        EqualSign
    }
}