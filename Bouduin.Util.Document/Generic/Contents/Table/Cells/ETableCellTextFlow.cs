using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    /// <summary>
    /// Specifies the direction of text flow inside the cell.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETableCellTextFlow
    {
        [RtfControlWord("cltxlrtb")] LeftToRightTopToBottom,
        [RtfControlWord("cltxtbrl")] TopToBottomRightToLeft,
        [RtfControlWord("cltxbtlr")] BottomToTopLeftToRight,
        [RtfControlWord("cltxlrtbv")] LeftToRightTopToBottomVertical,
        [RtfControlWord("cltxtbrlv")] TopToBottomRightToLeftVertical
    }
}