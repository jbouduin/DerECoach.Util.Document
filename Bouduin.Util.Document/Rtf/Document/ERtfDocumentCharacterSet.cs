using Bouduin.Util.Document.Rtf.Attributes;
// ReSharper disable InconsistentNaming

namespace Bouduin.Util.Document.Rtf.Document
{
    /// <summary>
    /// Specifies RTF document character set.
    /// </summary>
    [RtfEnumAsControlWord(RtfEnumConversion.UseName)]
    public enum ERtfDocumentCharacterSet
    {
        ANSI,
        Mac,
        PC,
        PCa
    }
}