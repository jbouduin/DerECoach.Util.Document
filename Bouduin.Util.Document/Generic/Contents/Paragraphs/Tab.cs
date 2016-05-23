using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{

    /// <summary>
    /// Represents a tab.
    /// </summary>
    internal class Tab : ITab
    {
        #region fields --------------------------------------------------------

        private ETabKind _kind = ETabKind.Normal;
        private ETabLead _lead = ETabLead.None;

        #endregion

        #region ITab members --------------------------------------------------

        [RtfControlWord, RtfInclude(ConditionMember = "IsNotBar")]
        public ETabKind Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        [RtfControlWord]
        public ETabLead Lead
        {
            get { return _lead; }
            set { _lead = value; }
        }

        [RtfControlWord("tx"), RtfInclude(ConditionMember = "IsNotBar")]
        public int TabPosition
        {
            get { return Position; }
        }

        [RtfControlWord("tb"), RtfInclude(ConditionMember = "Bar")]
        public int BarPosition
        {
            get { return Position; }
        }

        public bool Bar { get; set; }

        public bool IsNotBar
        {
            get { return !Bar; }
        }

        public int Position { get; set; }

        #endregion

        #region constructor ---------------------------------------------------

        /// <summary>
        /// Creates an instance of ESCommon.Rtf.RtfTab class.
        /// </summary>
        /// <param name="position">Tab position in twips</param>
        public Tab(int position)
        {
            Position = position;
        }

        /// <summary>
        /// Creates an instance of ESCommon.Rtf.RtfTab class.
        /// </summary>
        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        public Tab(int position, ETabKind kind)
        {
            Position = position;
            _kind = kind;
        }

        /// <summary>
        /// Creates an instance of ESCommon.Rtf.RtfTab class.
        /// </summary>
        /// <param name="position">Tab position in twips</param>
        /// <param name="lead">Tab lead</param>
        public Tab(int position, ETabLead lead)
        {
            Position = position;
            _lead = lead;
        }

        /// <summary>
        /// Creates an instance of ESCommon.Rtf.RtfTab class.
        /// </summary>
        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        /// <param name="lead">Tab lead</param>
        public Tab(int position, ETabKind kind, ETabLead lead)
        {
            Position = position;
            _kind = kind;
            _lead = lead;
        }

        #endregion
    }
}