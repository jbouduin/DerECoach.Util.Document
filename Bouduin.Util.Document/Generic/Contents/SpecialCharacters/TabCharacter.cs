using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.SpecialCharacters
{
    /// <summary>
    /// Represents a tab character.
    /// </summary>
    [RtfControlWord("tab")]
    internal class TabCharacter : ParagraphContent, ITabCharacter
    {

    }
}