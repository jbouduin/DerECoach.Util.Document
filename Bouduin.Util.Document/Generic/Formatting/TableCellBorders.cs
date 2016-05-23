using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Represents table cell borders.
    /// </summary>
    internal class TableCellBorders
    {
        private readonly Border _top = new Border();

        private readonly Border _left = new Border();

        private readonly Border _bottom = new Border();

        private readonly Border _right = new Border();

        /// <summary>
        /// Gets the top border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrt"), RtfInclude(ConditionMember = "IsTopBorderSet")]
        public Border Top
        {
            get { return _top; }
        }

        /// <summary>
        /// Gets the left border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrl"), RtfInclude(ConditionMember = "IsLeftBorderSet")]
        public Border Left
        {
            get { return _left; }
        }

        /// <summary>
        /// Gets the bottom border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrb"), RtfInclude(ConditionMember = "IsBottomBorderSet")]
        public Border Bottom
        {
            get { return _bottom; }
        }

        /// <summary>
        /// Gets the right border of the cell.
        /// </summary>
        [RtfControlWord("clbrdrr"), RtfInclude(ConditionMember = "IsRightBorderSet")]
        public Border Right
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
    }
}