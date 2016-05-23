using Bouduin.Util.Common.Extensions;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    [RtfControlWord("par")]
    internal class Paragraph : AParagraph
    {
        [RtfIgnore]
        public IParagraphFormatting InheritedFormatting
        {
            get { return (Parent as IBaseParagraph).IfNotNull(notNull => notNull.GetFormatting()); }
        }
        
        public Paragraph()
        {
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        public Paragraph(string text) : base(text)
        {
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        public Paragraph(IParagraphContent text) : base(text)
        {
        }

        /// <summary>
        /// Returns IParagraphFormatting of the paragraph.
        /// </summary>
        public override IParagraphFormatting GetFormatting()
        {
            return InheritedFormatting;
        }
    }
}