using System.Collections.ObjectModel;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    public interface IBaseParagraph : IDocumentContent
    {
        ReadOnlyCollection<IParagraphContent> Contents { get; }
        ReadOnlyCollection<IBaseParagraph> Paragraphs { get; }

        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        void AppendText(string text);

        /// <summary>
        /// Add contents to paragraph contents
        /// </summary>
        void AppendContent(IParagraphContent text);

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
        void AppendParagraph(IBaseParagraph paragraph);

        IParagraphFormatting GetFormatting();
    
    }

    internal interface IBaseParagraphInternal : IBaseParagraph, IDocumentContentInternal
    {
        bool IsPartOfATable { get; set; }
    }
}