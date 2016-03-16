using Bouduin.Util.Document.Rtf.Contents.Paragraphs;

namespace Bouduin.Util.Document.Rtf.Contents.Text
{
    /// <summary>
    /// Can be used within a paragraph
    /// </summary>
    public abstract class RtfParagraphContentBase
    {
        internal ARtfParagraph ParagraphInternal;

        public ARtfParagraph Paragraph
        {
            get { return ParagraphInternal; }
        }
    }
}
