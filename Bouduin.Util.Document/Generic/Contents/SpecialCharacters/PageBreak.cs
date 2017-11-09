using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.SpecialCharacters
{
    /// <summary>
    /// Represents a page break.
    /// </summary>
    [RtfControlWord("page")]
    internal class PageBreak : ADocumentContent, IPageBreak
    {

    }
}