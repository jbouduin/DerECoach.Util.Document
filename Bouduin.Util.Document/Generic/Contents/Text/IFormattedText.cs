namespace Bouduin.Util.Document.Generic.Contents.Text
{
    public interface IFormattedText: IText
    {
        /// <summary>
        /// Index of an entry in the font table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int FontIndex { get; set; }

        /// <summary>
        /// Gets the font size in half points.
        /// </summary>
        int HalfPointFontSize { get; }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int TextColorIndex { get; set; }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int BackgroundColorIndex { get; set; }

        bool Bold { get; set; }
        bool Italic { get; set; }
        bool Underline { get; set; }
        bool Subscript { get; set; }
        bool Superscript { get; set; }
        bool Caps { get; set; }
        bool SmallCaps { get; set; }

        /// <summary>
        /// Gets string value of the text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Font size in points. Default value 0 is ignored by RtfWriter.
        /// </summary>
        float FontSize { get; set; }

        /// <summary>
        /// Applies specified formatting to the text.
        /// </summary>
        /// <param name="formatting">Character formatting to apply.</param>
        void SetFormatting(ECharacterFormatting formatting);
    }
}