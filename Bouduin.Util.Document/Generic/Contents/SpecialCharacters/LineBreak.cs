using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.SpecialCharacters
{
    /// <summary>
    /// Represents a line break.
    /// </summary>
    [RtfControlWord("line")]
    internal class LineBreak : ParagraphContent, ILineBreak
    {

    }
}