using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Table.Rows
{
    public interface ITableRowPadding
    {
        int Left { get; set; }
        int Top { get; set; }
        int Bottom { get; set; }
        int Right { get; set; }
        EPaddingUnits LeftUnits { get; set; }
        EPaddingUnits TopUnits { get; set; }
        EPaddingUnits BottomUnits { get; set; }
        EPaddingUnits RightUnits { get; set; }

        /// <summary>
        /// Gets a Boolean value indicating whether left padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        bool IsLeftPaddingSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether top padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        bool IsTopPaddingSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether bottom padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        bool IsBottomPaddingSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether right padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        bool IsRightPaddingSet { get; }
    }
}