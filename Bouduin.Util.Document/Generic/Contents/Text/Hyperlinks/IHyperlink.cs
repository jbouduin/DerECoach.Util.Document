
namespace Bouduin.Util.Document.Generic.Contents.Text
{
    public interface IHyperlink: IParagraphContent
    {
        /// <summary>
        /// Gets or sets hyperlink location.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets hyperlink text.
        /// </summary>
        IFormattedText Text { get; set; }
        
    }
}