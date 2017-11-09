using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    public interface ITableCellBorders
    {
        /// <summary>
        /// Gets the top border of the cell.
        /// </summary>
        IBorder Top { get; }

        /// <summary>
        /// Gets the left border of the cell.
        /// </summary>
        IBorder Left { get; }

        /// <summary>
        /// Gets the bottom border of the cell.
        /// </summary>
        IBorder Bottom { get; }

        /// <summary>
        /// Gets the right border of the cell.
        /// </summary>
        IBorder Right { get; }
        
    }

    internal interface ITableCellBordersInternal : ITableCellBorders
    {
        /// <summary>
        /// Gets a Boolean value indicating whether top border of the cell is set.
        /// </summary>
        bool IsTopBorderSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether left border of the cell is set.
        /// </summary>
        bool IsLeftBorderSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether bottom border of the cell is set.
        /// </summary>
        bool IsBottomBorderSet { get; }

        /// <summary>
        /// Gets a Boolean value indicating whether right border of the cell is set.
        /// </summary>
        bool IsRightBorderSet { get; }
    }
}