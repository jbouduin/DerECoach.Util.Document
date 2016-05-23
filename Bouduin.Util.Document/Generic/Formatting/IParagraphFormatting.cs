namespace Bouduin.Util.Document.Generic.Formatting
{
    public interface IParagraphFormatting
    {
        /// <summary>
        /// Default is left.
        /// </summary>
        ETextAlign Align { get; set; }

        /// <summary>
        /// Paragraph first line indent in twips. Default is 0.
        /// </summary>
        int FirstLineIndent { get; set; }

        /// <summary>
        /// Paragraph left indent in twips. Default is 0.
        /// </summary>
        int IndentLeft { get; set; }

        /// <summary>
        /// Paragraph right indent in twips. Default is 0.
        /// </summary>
        int IndentRight { get; set; }

        /// <summary>
        /// Gets space between lines in twips. The value is used by RtfWriter.
        /// </summary>
        int TwipLineSpacing { get; }

        /// <summary>
        /// Space before paragraph in twips. Default is 0.
        /// </summary>
        int SpaceBefore { get; set; }

        /// <summary>
        /// Space after paragraph in twips. Default is 0.
        /// </summary>
        int SpaceAfter { get; set; }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int BackgroundColorIndex { get; set; }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int TextColorIndex { get; set; }

        /// <summary>
        /// Index of an entry in the font table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int FontIndex { get; set; }

        /// <summary>
        /// Gets the font size in half points. Used by RtfWriter.
        /// </summary>
        int HalfPointFontSize { get; }

        /// <summary>
        /// Font size in points. Default is 12.
        /// </summary>
        float FontSize { get; set; }

        /// <summary>
        /// Space between lines in percent
        /// . Default is 0 and the space is automatically determined by the tallest character in the line.
        /// </summary>
        float LineSpacingPercent { get; set; }
    }
}