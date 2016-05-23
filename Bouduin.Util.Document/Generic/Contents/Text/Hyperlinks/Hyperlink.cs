using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks
{
    /// <summary>
    /// Represents hyperlink.
    /// </summary>
    [RtfControlWord("field"), RtfEnclosingBraces]
    internal class Hyperlink : ParagraphContent, IHyperlink
    {
        /// <summary>
        /// Gets IHyperlinkLocation 
        /// </summary>
        [RtfInclude]
        public IHyperlinkLocation HyperlinkLocation { get; private set; }

        /// <summary>
        /// Gets RtfHyperlinkText 
        /// </summary>
        [RtfInclude]
        public IHyperlinkText HyperlinkTextText { get; private set; }

        /// <summary>
        /// Gets or sets hyperlink location.
        /// </summary>
        public string Location
        {
            get { return HyperlinkLocation != null ? HyperlinkLocation.Address : string.Empty; }
            set
            {
                if (HyperlinkLocation != null)
                {
                    HyperlinkLocation.Address = value;
                }
                else
                {
                    HyperlinkLocation = new HyperlinkLocation(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets hyperlink text.
        /// </summary>
        public IFormattedText Text
        {
            get { return HyperlinkTextText != null ? HyperlinkTextText.Text : null; }
            set
            {
                if (HyperlinkTextText != null)
                {
                    HyperlinkTextText.Text = value;
                }
                else
                {
                    HyperlinkTextText = new HyperlinkText(value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of IHyperlink class.
        /// </summary>
        /// <param name="address">URL address</param>
        /// <param name="text">Formatted text</param>
        public Hyperlink(string address, IFormattedText text)
        {
            HyperlinkLocation = new HyperlinkLocation(address);
            HyperlinkTextText = new HyperlinkText(text);
        }

        

        
    }
}