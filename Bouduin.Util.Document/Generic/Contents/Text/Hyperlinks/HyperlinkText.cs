using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks
{
    /// <summary>
    /// Represents hyperlink text.
    /// </summary>
    [RtfControlWord("fldrslt"), RtfEnclosingBraces]
    internal class HyperlinkText : IHyperlinkText
    {
        /// <summary>
        /// Gets or sets hyperlink text.
        /// </summary>
        [RtfInclude]
        public IFormattedText Text { get; set; }

        /// <summary>
        /// Initializes a new instance of HyperlinkText.
        /// </summary>
        /// <param name="text">Hyperlink text</param>
        public HyperlinkText(IFormattedText text)
        {
            Text = text;
        }
    }
}