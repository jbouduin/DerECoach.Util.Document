using System.Text;

namespace Bouduin.Util.Document.Rtf.Contents.Text
{
    public abstract class RtfTextBase : RtfParagraphContentBase
    {
        protected StringBuilder sb;

        public RtfTextBase()
        {
            sb = new StringBuilder();
        }

        public RtfTextBase(string text)
        {
            sb = new StringBuilder(text);
        }

        /// <summary>
        /// Appends text to the current object.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public void AppendText(string text)
        {
            sb.Append(text);
        }
    }
}