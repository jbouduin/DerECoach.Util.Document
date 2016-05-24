using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Represents table cell borders.
    /// </summary>
    internal class TableCellBorders
    {
        #region fields --------------------------------------------------------

        private readonly IBorder _top;
        private readonly IBorder _left;
        private readonly IBorder _bottom;
        private readonly IBorder _right;

        #endregion

        #region ITableCellBorders members -------------------------------------

        /// <summary>
        /// Gets the top border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrt"), RtfInclude(ConditionMember = "IsTopBorderSet")]
        public IBorder Top
        {
            get { return _top; }
        }

        /// <summary>
        /// Gets the left border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrl"), RtfInclude(ConditionMember = "IsLeftBorderSet")]
        public IBorder Left
        {
            get { return _left; }
        }

        /// <summary>
        /// Gets the bottom border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrb"), RtfInclude(ConditionMember = "IsBottomBorderSet")]
        public IBorder Bottom
        {
            get { return _bottom; }
        }

        /// <summary>
        /// Gets the right border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrr"), RtfInclude(ConditionMember = "IsRightBorderSet")]
        public IBorder Right
        {
            get { return _right; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether top border of the cell is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsTopBorderSet
        {
            get { return Top.Width > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether left border of the cell is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsLeftBorderSet
        {
            get { return Left.Width > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether bottom border of the cell is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsBottomBorderSet
        {
            get { return Bottom.Width > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether right border of the cell is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsRightBorderSet
        {
            get { return Right.Width > 0; }
        }

        #endregion

        #region constructor ---------------------------------------------------

        public TableCellBorders(ITwipConverter twipConverter)
        {
            _top = new Border(twipConverter);
            _left = new Border(twipConverter);
            _bottom = new Border(twipConverter);
            _right = new Border(twipConverter);
        }

        #endregion
    }
}