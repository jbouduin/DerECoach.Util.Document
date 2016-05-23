namespace Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks
{
    public interface IHyperlinkLocation
    {
        /// <summary>
        /// RTF field type.
        /// </summary>
        string FieldType { get; }

        /// <summary>
        /// Gets or sets hyperlink address.
        /// </summary>
        string Address { get; set; }
    }
}