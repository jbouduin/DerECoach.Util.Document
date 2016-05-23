using System.Drawing;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Header
{
    /// <summary>
    /// Represents a color.
    /// </summary>
    [RtfEnclosingBraces(Braces = false, ClosingSemicolon = true)]
    internal class DocumentColor
    {
        public static readonly DocumentColor Auto = new DocumentColor(-1, -1, -1);

        #region fields --------------------------------------------------------
        private readonly int _red;
        private readonly int _green;
        private readonly int _blue;
        #endregion

        #region properties ----------------------------------------------------

        [RtfControlWord, RtfInclude(ConditionMember = "IsNotAuto")]
        public int Red
        {
            get { return _red; }
        }

        [RtfControlWord, RtfInclude(ConditionMember = "IsNotAuto")]
        public int Green
        {
            get { return _green; }
        }

        [RtfControlWord, RtfInclude(ConditionMember = "IsNotAuto")]
        public int Blue { get { return _blue; } }

        /// <summary>
        /// Condition member used by RtfWriter.
        /// </summary>
        public bool IsNotAuto
        {
            get { return Red >= 0 && Green >= 0 && Blue >= 0; }
        }
        #endregion

        #region constructor ---------------------------------------------------
        public DocumentColor(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfColor class.
        /// </summary>
        public DocumentColor(Color color)
        {
            _red = color.R;
            _green = color.G;
            _blue = color.B;
        }
        #endregion

        #region equality members ----------------------------------------------

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DocumentColor) obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _red;
                hashCode = (hashCode * 397) ^ _green;
                hashCode = (hashCode * 397) ^ _blue;
                return hashCode;
            }
        }

        protected bool Equals(DocumentColor other)
        {
            return _red == other._red && _green == other._green && _blue == other._blue;
        }

        public static bool operator ==(DocumentColor left, DocumentColor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DocumentColor left, DocumentColor right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region explicit operators ----------------------------------------------
        public static explicit operator Color(DocumentColor c)
        {
            return Color.FromArgb(c.Red, c.Green, c.Blue);
        }

        public static explicit operator DocumentColor(Color c)
        {
            return new DocumentColor(c);
        }
        #endregion
    }
}
