using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    /// <summary>
    /// Represents hyperlink.
    /// </summary>
    [RtfControlWord("field"), RtfEnclosingBraces]
    internal class Hyperlink : ParagraphContent, IHyperlink
    {
        /// <summary>
        /// Gets RtfHyperlinkLocation used by RtfWriter.
        /// </summary>
        [RtfInclude]
        public RtfHyperlinkLocation RtfLocation { get; private set; }

        /// <summary>
        /// Gets RtfHyperlinkText used by RtfWriter.
        /// </summary>
        [RtfInclude]
        public RtfHyperlinkText RtfText { get; private set; }

        /// <summary>
        /// Gets or sets hyperlink location.
        /// </summary>
        public string Location
        {
            get { return RtfLocation != null ? RtfLocation.Address : string.Empty; }
            set
            {
                if (RtfLocation != null)
                {
                    RtfLocation.Address = value;
                }
                else
                {
                    RtfLocation = new RtfHyperlinkLocation(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets hyperlink text.
        /// </summary>
        public IFormattedText Text
        {
            get { return RtfText != null ? RtfText.Text : null; }
            set
            {
                if (RtfText != null)
                {
                    RtfText.Text = value;
                }
                else
                {
                    RtfText = new RtfHyperlinkText(value);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.ARtfHyperlink class.
        /// </summary>
        /// <param name="address">URL address</param>
        /// <param name="text">Formatted text</param>
        public Hyperlink(string address, IFormattedText text)
        {
            RtfLocation = new RtfHyperlinkLocation(address);
            RtfText = new RtfHyperlinkText(text);
        }

        /// <summary>
        /// Represents hyperlink location.
        /// </summary>
        [RtfControlWord("fldinst"), RtfEnclosingBraces]
        public class RtfHyperlinkLocation
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
            /// Initializes a new instance of ESCommon.Rtf.RtfHyperlinkLocation class.
            /// </summary>
            /// <param name="address">URL address</param>
            public RtfHyperlinkLocation(string address)
            {
                Address = address;
            }
        }

        /// <summary>
        /// Represents hyperlink text.
        /// </summary>
        [RtfControlWord("fldrslt"), RtfEnclosingBraces]
        public class RtfHyperlinkText
        {
            /// <summary>
            /// Gets or sets hyperlink text.
            /// </summary>
            [RtfInclude]
            public IFormattedText Text { get; set; }

            /// <summary>
            /// Initializes a new instance of ESCommon.Rtf.RtfHyperlinkText class.
            /// </summary>
            /// <param name="text">Hyperlink text</param>
            public RtfHyperlinkText(IFormattedText text)
            {
                Text = text;
            }
        }
    }
}