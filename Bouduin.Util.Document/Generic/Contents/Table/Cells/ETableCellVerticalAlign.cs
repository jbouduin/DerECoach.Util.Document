using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    /// <summary>
    /// Specifies vertical align of the text inside the cell.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETableCellVerticalAlign
    {
        [RtfControlWord("clvertalt")] Top,
        [RtfControlWord("clvertalc")] Center,
        [RtfControlWord("clvertalb")] Bottom
    }
}