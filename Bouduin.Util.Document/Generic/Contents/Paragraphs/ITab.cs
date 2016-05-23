namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    public interface ITab
    {
        /// <summary>
        /// Gets or sets tab kind property.
        /// </summary>
        ETabKind Kind { get; set; }

        /// <summary>
        /// Gets or sets tab lead property.
        /// </summary>
        ETabLead Lead { get; set; }

        /// <summary>
        /// Gets tab position in twips.
        /// </summary>
        int TabPosition { get; }

        /// <summary>
        /// Gets bar tab position in twips.
        /// </summary>
        int BarPosition { get; }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether a vertical bar is drawn at the tab position.
        /// </summary>
        bool Bar { get; set; }

        /// <summary>
        /// Condition member
        /// </summary>
        bool IsNotBar { get; }

        /// <summary>
        /// Gets or sets tab position in twips.
        /// </summary>
        int Position { get; set; }
    }
}