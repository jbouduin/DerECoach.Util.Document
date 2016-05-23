using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    

    /// <summary>
    /// Represents table row padding.
    /// </summary>
    internal class RtfTableRowPadding
    {
        private EPaddingUnits _leftUnits = EPaddingUnits.Twips;
        private EPaddingUnits _topUnits = EPaddingUnits.Twips;
        private EPaddingUnits _bottomUnits = EPaddingUnits.Twips;
        private EPaddingUnits _rightUnits = EPaddingUnits.Twips;


        [RtfControlWord("trspdl"), RtfInclude(ConditionMember = "IsLeftPaddingSet")]
        public int Left { get; set; }

        [RtfControlWord("trspdt"), RtfInclude(ConditionMember = "IsTopPaddingSet")]
        public int Top { get; set; }

        [RtfControlWord("trspdb"), RtfInclude(ConditionMember = "IsBottomPaddingSet")]
        public int Bottom { get; set; }

        [RtfControlWord("trspdr"), RtfInclude(ConditionMember = "IsRightPaddingSet")]
        public int Right { get; set; }


        [RtfControlWord("trspdrfl"), RtfInclude(ConditionMember = "IsLeftPaddingSet")]
        public EPaddingUnits LeftUnits
        {
            get { return _leftUnits; }
            set { _leftUnits = value; }
        }

        [RtfControlWord("trspdrft"), RtfInclude(ConditionMember = "IsTopPaddingSet")]
        public EPaddingUnits TopUnits
        {
            get { return _topUnits; }
            set { _topUnits = value; }
        }

        [RtfControlWord("trspdrfb"), RtfInclude(ConditionMember = "IsBottomPaddingSet")]
        public EPaddingUnits BottomUnits
        {
            get { return _bottomUnits; }
            set { _bottomUnits = value; }
        }

        [RtfControlWord("trspdrfr"), RtfInclude(ConditionMember = "IsRightPaddingSet")]
        public EPaddingUnits RightUnits
        {
            get { return _rightUnits; }
            set { _rightUnits = value; }
        }


        /// <summary>
        /// Gets a Boolean value indicating whether left padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsLeftPaddingSet
        {
            get { return Left > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether top padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsTopPaddingSet
        {
            get { return Top > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether bottom padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsBottomPaddingSet
        {
            get { return Bottom > 0; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether right padding of the row is set. This property is used by RtfWriter.
        /// </summary>
        public bool IsRightPaddingSet
        {
            get { return Right > 0; }
        }
    }
}