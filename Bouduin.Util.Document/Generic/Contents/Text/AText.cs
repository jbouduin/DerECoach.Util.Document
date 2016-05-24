using System.Text;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    internal abstract class AText : ParagraphContent, IText
    {
        #region fields --------------------------------------------------------
        protected StringBuilder Sb;
        #endregion

        #region IText members -------------------------------------------------
        /// <summary>
        /// Appends text to the current object.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public void AppendText(string text)
        {
            Sb.Append(text);
        }
        #endregion

        #region constructor ---------------------------------------------------
        protected AText(string text)
        {
            Sb = string.IsNullOrEmpty(text) ? new StringBuilder() : new StringBuilder(text);
        }

        #endregion
    }
}