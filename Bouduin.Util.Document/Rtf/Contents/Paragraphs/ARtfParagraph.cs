using Bouduin.Util.Document.Rtf.Contents.Text;
using Bouduin.Util.Document.Rtf.Document;
using Bouduin.Util.Document.Rtf.Formatting;

namespace Bouduin.Util.Document.Rtf.Contents.Paragraphs
{
    public abstract class ARtfParagraph : ARtfDocumentContent
    {
        protected bool isPartOfATable = false;
        protected RtfParagraphContentsCollection contents;
        protected RtfParagraphCollection paragraphs;


        internal override RtfDocument DocumentInternal
        {
            get
            {
                return base.DocumentInternal;
            }
            set
            {
                base.DocumentInternal = value;

                foreach (var paragraph in paragraphs)
                {
                    paragraph.DocumentInternal = value;
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfParagraph class.
        /// </summary>
        protected ARtfParagraph()
        {
            contents = new RtfParagraphContentsCollection(this);
            paragraphs = new RtfParagraphCollection(this);
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        protected ARtfParagraph(string text) : this()
        {
            AppendText(text);
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        protected ARtfParagraph(RtfParagraphContentBase text) : this()
        {
            AppendText(text);
        }


        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        public void AppendText(string text)
        {
            AppendText(new RtfText(text));
        }

        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        public void AppendText(RtfParagraphContentBase text)
        {
            if (paragraphs.Count == 0)
            {
                contents.Add(text);
            }
            else
            {
                paragraphs[paragraphs.Count - 1].AppendText(text);
            }
        }

        /// <summary>
        /// Add an empty paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph()
        {
            paragraphs.Add(new RtfParagraph());
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(string text)
        {
            AppendParagraph(new RtfParagraph(text));
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(RtfParagraphContentBase text)
        {
            AppendParagraph(new RtfParagraph(text));
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(RtfParagraph paragraph)
        {
            paragraphs.Add(paragraph);
        }


        public abstract RtfParagraphFormatting GetFormatting();
    }
}