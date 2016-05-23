using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks
{
    /// <summary>
    /// Represents hyperlink location.
    /// </summary>
    [RtfControlWord("fldinst"), RtfEnclosingBraces]
    internal class HyperlinkLocation : IHyperlinkLocation
    {
        /// <summary>
        /// RTF field type.
        /// </summary>
        [RtfTextData(RtfTextDataType.Raw)]
        public string FieldType
        {
            get { return "HYPERLINK"; }
        }

        /// <summary>
        /// Gets or sets hyperlink address.
        /// </summary>
        [RtfTextData(RtfTextDataType.HyperLink, Quotes = true)]
        public string Address { get; set; }

        /// <summary>
        /// Initializes a new instance of IHyperlinkLocation class.
        /// </summary>
        /// <param name="address">URL address</param>
        public HyperlinkLocation(string address)
        {
            Address = address;
        }
    }
}