using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.SpecialCharacters
{
    /// <summary>
    /// Represents a nonbreaking space.
    /// </summary>
    [RtfControlWord("~")]
    internal class NonbreakingSpace : ParagraphContent, INonbreakingSpace
    {

    }
}