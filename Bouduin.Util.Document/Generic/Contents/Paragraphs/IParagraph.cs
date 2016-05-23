using System.Collections.ObjectModel;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    public interface IParagraph : IDocumentContent
    {
        bool IsPartOfATable { get; }
        ObservableCollection<IParagraphContent> Contents { get; }
        ObservableCollection<IParagraph> Paragraphs { get; }

        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        void AppendText(string text);

        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        void AppendText(IParagraphContent text);

        /// <summary>
        /// Add an empty paragraph with inherited formatting
        /// </summary>
        void AppendParagraph();

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        void AppendParagraph(string text);

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        void AppendParagraph(IParagraphContent text);

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        void AppendParagraph(IParagraph paragraph);

        IParagraphFormatting GetFormatting();
        void SetDocument(IDocument document);
        void SetParent(IDocumentContent parentDocumentContent);
    }
}