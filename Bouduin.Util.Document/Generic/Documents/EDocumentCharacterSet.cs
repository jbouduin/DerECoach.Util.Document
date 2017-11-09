using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

// ReSharper disable InconsistentNaming

namespace Bouduin.Util.Document.Generic.Documents
{
    /// <summary>
    /// Specifies RTF document character set.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseName)]
    public enum EDocumentCharacterSet
    {
        ANSI,
        Mac,
        PC,
        PCa
    }
}