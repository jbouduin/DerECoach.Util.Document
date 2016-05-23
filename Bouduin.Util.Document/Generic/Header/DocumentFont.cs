using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Header
{
    
    /// <summary>
    /// Represents a font.
    /// </summary>
    [RtfControlWord("f", IsIndexed = true), RtfEnclosingBraces(ClosingSemicolon = true)]
    internal class DocumentFont : IDocumentFont
    {
        #region fields --------------------------------------------------------
        private readonly EFontFamily _fontFamily = EFontFamily.Default;
        private readonly ECharacterSet _characterSet = ECharacterSet.Default;
        private readonly EFontPitch _pitch = EFontPitch.Default;
        private readonly string _fontName;
        #endregion

        #region properties ----------------------------------------------------
        [RtfControlWord]
        public EFontFamily FontFamily
        {
            get { return _fontFamily; }
        }

        [RtfControlWord]
        public ECharacterSet CharacterSet
        {
            get { return _characterSet; }
        }

        [RtfControlWord]
        public EFontPitch Pitch
        {
            get { return _pitch; }
        }

        [RtfTextData]
        public string FontName
        {
            get { return _fontName; }
        }
        #endregion

        #region constructor ---------------------------------------------------

        public DocumentFont(string fontName)
        {
            _fontName = fontName;
        }

        public DocumentFont(string fontName, ECharacterSet characterSet)
        {
            _fontName = fontName;
            _characterSet = characterSet;
        }

        public DocumentFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily)
        {
            _fontName = fontName;
            _characterSet = characterSet;
            _fontFamily = fontFamily;
        }

        public DocumentFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily, EFontPitch pitch)
        {
            _fontName = fontName;
            _characterSet = characterSet;
            _fontFamily = fontFamily;
            _pitch = pitch;
        }
        #endregion

        #region equality members ----------------------------------------------

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DocumentFont) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) _fontFamily;
                hashCode = (hashCode*397) ^ (int) _characterSet;
                hashCode = (hashCode*397) ^ (int) _pitch;
                hashCode = (hashCode*397) ^ (_fontName != null ? _fontName.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(DocumentFont other)
        {
            return _fontFamily == other._fontFamily && _characterSet == other._characterSet && _pitch == other._pitch &&
                   string.Equals(_fontName, other._fontName);
        }

        public static bool operator ==(DocumentFont left, DocumentFont right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DocumentFont left, DocumentFont right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}