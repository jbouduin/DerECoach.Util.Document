using System.Collections.ObjectModel;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    public interface IFormattedParagraph : IBaseParagraph
    {
        /// <summary>
        /// Gets or sets a Boolean value indicating that font (character) formatting is reset to default value
        /// </summary>
        bool ResetFormatting { get; set; }

        /// <summary>
        /// Gets or sets paragraph formatting
        /// </summary>
        IParagraphFormatting Formatting { get; }

        /// <summary>
        /// Default language is English (United States).
        /// </summary>
        ELanguage Language { get; set; }

        /// <summary>
        /// Gets an array of paragraph tabs.
        /// </summary>
        ObservableCollection<ITab> Tabs { get; }

        /// <summary>
        /// Condition member used by RtfWriter.
        /// </summary>
        bool IsNotDefaultLanguage { get; }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether RtfWriter must include formatting
        /// </summary>
        bool IsFormattingIncluded { get; set; }

        /// <summary>
        /// Clears all the contents of the paragraph.
        /// </summary>
        void Clear();
    }
}