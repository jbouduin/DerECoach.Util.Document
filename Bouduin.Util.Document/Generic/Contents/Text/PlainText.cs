using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    /// <summary>
    /// Represents plain text.
    /// </summary>
    internal class PlainText : AText, IPlainText
    {
        /// <summary>
        /// Gets string value of the text.
        /// </summary>
        [RtfTextData]
        public string TextData
        {
            get { return Sb.ToString(); }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfText class.
        /// </summary>
        public PlainText(string text) : base(text)
        {
        }
    }
}